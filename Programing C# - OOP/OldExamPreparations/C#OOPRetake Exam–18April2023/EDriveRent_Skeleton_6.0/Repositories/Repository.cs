using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected List<T> collection;

        public Repository()
        {
            this.collection = new List<T>();
        }

        public IReadOnlyCollection<T> Collection { get => this.collection.AsReadOnly(); }

        public void AddModel(T model) => this.collection.Add(model);

        public IReadOnlyCollection<T> GetAll() => this.Collection;

        public abstract T FindById(string identifier);
       
        public bool RemoveById(string identifier) => this.collection.Remove(FindById(identifier));

    }
}
