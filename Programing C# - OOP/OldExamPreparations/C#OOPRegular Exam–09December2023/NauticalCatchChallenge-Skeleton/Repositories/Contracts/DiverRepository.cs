using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories.Contracts
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> models;

        public DiverRepository()
        {
            this.models=new List<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models { get => this.models.AsReadOnly(); }

        public void AddModel(IDiver model)
        {
            this.models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }
    }
}
