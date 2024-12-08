using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private List<T> models;

        public Repository() => this.models = new List<T>();
        public IReadOnlyCollection<T> Models { get => this.models.AsReadOnly(); }

        public void AddNew(T model) => this.models.Add(model);

        public abstract bool Exists(string name);

        public abstract T GetByName(string name);
    }
}
