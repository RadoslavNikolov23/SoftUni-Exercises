using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected List<T> models;

        protected Repository()
        {
            models = new List<T>();
        }
        public IReadOnlyCollection<T> Models { get => models.AsReadOnly(); }

        public void AddModel(T model) => this.models.Add(model);

        public abstract T FirstModel(string name);

        public bool RemoveModel(T model) => this.models.Remove(model);
    }
}
