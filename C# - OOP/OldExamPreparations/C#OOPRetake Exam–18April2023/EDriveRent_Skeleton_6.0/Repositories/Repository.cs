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
        private List<T> collection;

        public Repository()
        {
            this.collection = new List<T>();
        }

        public void AddModel(T model) => this.collection.Add(model);

        public IReadOnlyCollection<T> GetAll() => this.collection.AsReadOnly();

        public abstract T FindById(string identifier);
       
        public bool RemoveById(string identifier) => this.collection.Remove(FindById(identifier));

    }
}
