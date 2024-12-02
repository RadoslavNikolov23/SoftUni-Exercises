using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }
        public IReadOnlyCollection<T> Models { get; }

        public void AddModel(T model)
        {
            this.models.Add(model);
        }

        public abstract T FindByName(string name);
     

        public bool RemoveModel(T model)
        {
            return this.models.Remove(model);
        }
    }
}
