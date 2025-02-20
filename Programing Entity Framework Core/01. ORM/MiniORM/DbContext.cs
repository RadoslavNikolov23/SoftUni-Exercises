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
            typeof(DateTime),
            typeof(Guid)
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
            IEnumerable<object> DbSetsObjects = this.dbSetProperties.Select(pi => pi.Value.GetValue(this)!).ToArray()!;

            foreach (IEnumerable<object> dbset in DbSetsObjects)
            {
                IEnumerable<object> invalidEntities = dbset
                    .Where(e => !IsObjectValid(e))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidOperation, invalidEntities.Count(), dbset.GetType().Name));
                }
            }

            using (new ConnectionManager(this.connection))
            {
                using SqlTransaction transaction = this.connection.StartTransaction();
                {
                    foreach (IEnumerable dbset in DbSetsObjects)
                    {
                        Type dbSetType = dbset.GetType();
                        Type entityType = dbSetType.GetGenericArguments()[0];

                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.NonPublic | BindingFlags.Instance)!
                            .MakeGenericMethod(entityType);

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
                    }
                        transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tablename = GetTableName(typeof(TEntity));
            IEnumerable<string> columns = this.connection.FetchColumnNames(tablename);

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tablename, columns.ToArray());
            }

            IEnumerable<TEntity> modifiedEntities = dbSet.ChangeTracker.GetModifieldEntities(dbSet);
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tablename, columns.ToArray());
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tablename, columns.ToArray());

            }

        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            Dictionary<Type, PropertyInfo> dbSets = GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

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
            IEnumerable<PropertyInfo> collections = typeEntity.GetProperties()
                .Where(pi => pi.PropertyType.IsGenericType &&
                            pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (PropertyInfo collection in collections)
            {
                Type collectionType = collection.PropertyType.GetGenericArguments().First();
                MethodInfo mapCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .MakeGenericMethod(typeEntity, collectionType);
                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            IEnumerable<PropertyInfo> primaryKeys = collectionType.GetProperties()
                .Where(pk => pk.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();

            PropertyInfo foreignKey = entityType.GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>())!;


            bool isManyToMany = primaryKeys.Count() >= 2;
            if (isManyToMany)
            {
                primaryKey = collectionType.GetProperties()
                    .First(pk => collectionType
                                    .GetProperty(pk.GetCustomAttribute<ForeignKeyAttribute>()!.Name)!
                                    .PropertyType == entityType);
            }
            DbSet<TCollection> navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType].GetValue(this)!;
            
            foreach (TDbSet entity in dbSet)
            { 
               object primaryKeyValue = foreignKey.GetValue(entity)!;

                IEnumerable<TCollection> navigationEntities = navigationDbSet
                    .Where(ne => primaryKey.GetValue(ne)!.Equals(primaryKeyValue))
                    .ToArray();
                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {

            Type entityType = typeof(TEntity);
            IEnumerable<PropertyInfo> foreignKeys = entityType.GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (PropertyInfo foreignKey in foreignKeys)
            {
                string navigationPropertyName = foreignKey.GetCustomAttribute<ForeignKeyAttribute>()!.Name;
                PropertyInfo? navigationProperty = entityType.GetProperty(navigationPropertyName);

                if (navigationProperty == null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNavigationPropertyName, foreignKey.Name, navigationPropertyName));
                }

                object navigationDbSet = dbSetProperties[navigationProperty.PropertyType].GetValue(this)!;

                if (navigationDbSet == null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NavPropertyWithoutDbSetMessage, navigationPropertyName, navigationProperty.PropertyType));
                }

                PropertyInfo navigationPrimaryKey = navigationProperty.PropertyType.GetProperties()
                    .First(pk => pk.HasAttribute<KeyAttribute>());

                foreach (TEntity entity in dbSet)
                {
                    object foreignKeyValue = foreignKey.GetValue(entity)!;

                    if (foreignKeyValue == null)
                    {
                        navigationProperty.SetValue(entity, null);
                        continue;
                    }

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .FirstOrDefault(currentNP => navigationPrimaryKey.GetValue(currentNP)!.Equals(foreignKeyValue));
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
            string[] columns = GetEntityColumnNames(table);
            string tableName = GetTableName(table);
            return this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
            //IEnumerable<TEntity> fletchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
            //return fletchedRows;
        }

        private string GetTableName(Type tableType)
        {
            Attribute? tableNameAttr = Attribute.GetCustomAttribute(tableType, typeof(TableAttribute));

            if (tableNameAttr == null)
            {
                return this.dbSetProperties[tableType].Name;
            }

            if (tableNameAttr is TableAttribute tableNameAttributeConfoguret)
            {
                return tableNameAttributeConfoguret.Name;
            }

            throw new ArgumentException(String.Format(ExceptionMessages.NoTableNameFound, this.dbSetProperties[tableType].Name));
        }

        private string[] GetEntityColumnNames(Type table)
        {
            string tableName = GetTableName(table);
            IEnumerable<string> dbColumns = this.connection.FetchColumnNames(tableName);

            string[] columnsNames = table.GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) &&
                            !pi.HasAttribute<NotMappedAttribute>() &&
                            AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();
            
            //string[] columnsNames = table.GetProperties()
            //    .Where(pi => dbColumns.Contains(pi.Name) &&
            //                !pi.HasAttribute<NotMappedAttribute>() &&
            //                AllowedSqlTypes.Contains(pi.PropertyType))
            //    .Select(pi => pi.Name)
            //    .ToArray();

            return columnsNames;
        }




    }
}