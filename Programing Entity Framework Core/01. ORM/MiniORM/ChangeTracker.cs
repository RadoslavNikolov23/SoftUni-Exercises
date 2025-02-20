
namespace MiniORM
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    internal class ChangeTracker<T>
        where T : class, new()
    {

        /* The ChangeTracker class will track the:
                                 - added entities
                                 - modified entities
                                 - deleted entities*/

        private readonly ICollection<T> allEntities;
        private readonly ICollection<T> added;
        private readonly ICollection<T> removed;

        public IReadOnlyCollection<T> AllEntities => this.allEntities.ToList().AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.ToList().AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.ToList().AsReadOnly();


        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();
            this.allEntities = CloneEntities(entities);

        }

        private static ICollection<T> CloneEntities(IEnumerable<T> entities)
        {
            ICollection<T> clonedEntities = new List<T>();
            PropertyInfo[] propertiesClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (T entity in entities)
            {
                T clonedEntity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in propertiesClone)
                {
                    object value = property.GetValue(entity)!;
                    property.SetValue(clonedEntity, value);

                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity))!;
        }

        private static bool IsModifield(T proxyEntity, T entity)
        {
            PropertyInfo[] monitoredProperty = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (PropertyInfo propertyInfo in monitoredProperty)
            {
                object? peValue = propertyInfo.GetValue(proxyEntity);
                object? dbeValue = propertyInfo.GetValue(entity);

                if (peValue == null && dbeValue == null)
                {
                    continue;
                }

                if (!peValue!.Equals(dbeValue))
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(T entity)
        {
            this.added.Add(entity);
        }

        public void Remove(T Entity)
        {
            this.removed.Add(Entity);
        }

        public IEnumerable<T> GetModifieldEntities(DbSet<T> dbSet)
        {
            ICollection<T> modifieldEntities = new List<T>();
            PropertyInfo[] primaryKey = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (T proxyEntity in this.AllEntities)
            {
                IEnumerable<object> primaryKeyValues = GetPrimaryKeyValues(primaryKey, proxyEntity).ToArray();
                T entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKey, e).SequenceEqual(primaryKeyValues));

                bool isModified = IsModifield(proxyEntity, entity);

                if (isModified)
                {
                    modifieldEntities.Add(entity);
                }
            }
            return modifieldEntities;
        }


    }
}