using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T:class
    {
        protected List<T> all;

        public Repository()
        {
            this.all = new List<T>();
        }
        public IReadOnlyCollection<T> All { get => this.all.AsReadOnly(); }

        public void Add(T model)
        {
           this.all.Add(model);
        }

        public abstract T Get(string name);
        
           
        
    }
}
