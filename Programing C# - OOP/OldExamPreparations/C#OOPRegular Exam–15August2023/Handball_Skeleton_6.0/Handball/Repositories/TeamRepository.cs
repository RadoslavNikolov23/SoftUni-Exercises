using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;

        public TeamRepository()
        {
            this.models = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models { get => this.models.AsReadOnly(); }

        public void AddModel(ITeam model)=>this.models.Add(model);  
       
        public bool ExistsModel(string name)=>this.models.Any(t => t.Name == name);
        
        public ITeam GetModel(string name)=>this.models.FirstOrDefault(t => t.Name == name);

        public bool RemoveModel(string name)
        {
            ITeam team= this.models.FirstOrDefault(t => t.Name == name);
            return this.models.Remove(team);
        }
    }
}
