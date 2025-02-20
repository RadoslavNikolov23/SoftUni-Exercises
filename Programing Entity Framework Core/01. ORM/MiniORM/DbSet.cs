using System.Collections;

namespace MiniORM
{
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        /* The DbSet class will hold entities inside */

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal IList<TEntity> Entities { get; set; }

        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);

        }

        public int Count { get => this.Entities.Count; }
        public bool IsReadOnly { get => this.Entities.IsReadOnly; }

        public void Add(TEntity item)
        {
            if (item == null) 
                throw new ArgumentNullException(String.Format(ExceptionMessages.ItemCanBeNullAttribute));

            this.Entities.Add(item);
            ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (Entities.Any())
            {
                TEntity entity = Entities.First();
                Remove(entity);
            }
        }

        public bool Remove(TEntity item)
        {
            if (item == null) 
                throw new ArgumentNullException(String.Format(ExceptionMessages.ItemCanBeNullAttribute));

            bool removedSuccessfully = this.Entities.Remove(item);

            if (removedSuccessfully)
            {
                ChangeTracker.Remove(item);
            }
            return removedSuccessfully;

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities.ToArray())
            {
                Remove(entity);
            }
        }

        public bool Contains(TEntity item)
                => this.Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex)
                => this.Entities.CopyTo(array, arrayIndex);

        public IEnumerator<TEntity> GetEnumerator()
                => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();


    }
}