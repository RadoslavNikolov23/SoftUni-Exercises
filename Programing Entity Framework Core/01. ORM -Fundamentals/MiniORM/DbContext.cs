using Microsoft.Data.SqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;

namespace MiniORM
{
    public abstract class DbContext
    {
        /* The DbContext class holds all the DbSet (which are the tables) and the ChangeTracker. */

        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(decimal),
            typeof(float),
            typeof(double),
            typeof(bool),
            typeof(DateTime)
         };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            this.dbSetProperties = DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                InitializeDbSets();
            }
            MappAllRealtions();
        }


        public void SaveChanges()
        {
            object[] DbSets = dbSetProperties.Select(pi => pi.Value.GetValue(this)).ToArray()!;

            foreach (IEnumerable<object> dbset in DbSets)
            {
                IEnumerable<object> invalidEntities = dbset.Where(e => !IsObjectValid(e))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidOperation, invalidEntities.Count(), dbset.GetType().Name));
                }
            }

            using (new ConnectionManager(connection))
            {
                using (SqlTransaction transaction = connection.StartTransaction())
                {
                    foreach (IEnumerable dbset in DbSets)
                    {
                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.NonPublic | BindingFlags.Instance)!
                            .MakeGenericMethod(dbset.GetType());
                        try
                        {
                            try
                            {
                                persistMethod.Invoke(this, new object[] { dbset });
                            }
                            catch (TargetInvocationException e) when (e.InnerException is not null)
                            {
                                throw e.InnerException;
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Rollback!");
                            transaction.Rollback();
                            throw;
                        }
                        transaction.Commit();
                    }
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tablename = GetTableName(typeof(TEntity));
            string[] columns = this.connection.FetchColumnNames(tablename).ToArray();
            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tablename, columns);
            }

            TEntity[] modifiedEntities = dbSet.ChangeTracker.GetModifieldEntities(dbSet).ToArray();
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tablename, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tablename, columns);

            }

        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            Dictionary<Type, PropertyInfo> dbSets = GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(p => p.PropertyType.GetGenericArguments().First(), p => p);

            return dbSets;
        }

        private void InitializeDbSets()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSet in this.dbSetProperties)
            {
                Type dbSetType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();
            DbSet<TEntity> dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);

        }

        private void MappAllRealtions()
        {
            foreach (KeyValuePair<Type, PropertyInfo> dbSetProperty in this.dbSetProperties)
            {
                Type dbSetType = dbSetProperty.Key;
                MethodInfo mapRelationsGenerics = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .MakeGenericMethod(dbSetType);

                object dbSet = dbSetProperty.Value.GetValue(this)!;
                mapRelationsGenerics.Invoke(this, new object[] { dbSet });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type typeEntity = typeof(TEntity);
            MapNavigationProperties(dbSet);
            PropertyInfo[] collection = typeEntity.GetProperties()
                .Where(pi => pi.PropertyType.IsGenericType &&
                            pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (PropertyInfo propertyInfoItem in collection)
            {
                Type collectionType = propertyInfoItem.PropertyType.GetGenericArguments().First();
                MethodInfo mapCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .MakeGenericMethod(typeEntity, collectionType);
                mapCollectionMethod.Invoke(this, new object[] { dbSet, propertyInfoItem });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            PropertyInfo[] primaryKeys = entityType.GetProperties()
                .Where(pk => pk.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();
            PropertyInfo foreignKey = collectionType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            bool isManyToMany = primaryKeys.Length >= 2;
            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pk => collectionType.GetProperty(pk.GetCustomAttribute<ForeignKeyAttribute>()!.Name)!
                                             .PropertyType == entityType);
            }
            DbSet<TCollection> navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this)!;

            foreach (TDbSet entity in dbSet)
            {
                object? primaryKeyValue = foreignKey.GetValue(entity);
                TCollection[] navigationEntities = navigationDbSet
                    .Where(ne => primaryKey.GetValue(ne)!.Equals(primaryKeyValue))
                    .ToArray();
                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {

            Type entityType = typeof(TEntity);
            PropertyInfo[] foreignKeys = entityType.GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (PropertyInfo foreignKey in foreignKeys)
            {
                string navigationPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>()!.Name;
                PropertyInfo? navigationProperty = entityType.GetProperty(navigationPropertyName);

                object? navigationDbSet = dbSetProperties[navigationProperty!.PropertyType].GetValue(this);
                PropertyInfo navigationPrimaryKey = navigationProperty.PropertyType.GetProperties()
                    .First(pk => pk.HasAttribute<KeyAttribute>());

                foreach (TEntity entity in dbSet)
                {
                    object? foreignKeyValue = foreignKey.GetValue(entity);
                    object? navigationPropertyValue = ((IEnumerable<object>)navigationDbSet!)
                        .First(currentNE => navigationPrimaryKey.GetValue(currentNE)!.Equals(foreignKeyValue));
                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private bool IsObjectValid(object e)
        {
            ValidationContext validationContext = new ValidationContext(e);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            bool validationResult = Validator.TryValidateObject(e, validationContext, validationResults, true);
            return validationResult;
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class, new()
        {
            Type table = typeof(TEntity);
            string[] columns= GetEntityColumnNames(table);
            string tableName = GetTableName(table);
            TEntity[] fletchedRows=this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
            return fletchedRows;
        }

        private string GetTableName(Type type)
        {
            string tableName = ((TableAttribute)Attribute.GetCustomAttribute(type, typeof(TableAttribute))!).Name;

            if(tableName == null)
            {
                tableName = this.dbSetProperties[type].Name;
            }
            return tableName;
        }

        private string[] GetEntityColumnNames(Type table)
        {
            string tableName = GetTableName(table);
            IEnumerable<string> columns = this.connection.FetchColumnNames(tableName);

            string[] columnsNames= table.GetProperties()
                .Where(pi=> columns.Contains(pi.Name) &&
                            !pi.HasAttribute<NotMappedAttribute>() &&
                            AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return columnsNames;
        }




    }
}
