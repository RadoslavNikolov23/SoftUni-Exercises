using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;
        private int capacity=10;

        public TeamRepository()
        {
            this.models = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models { get => this.models.AsReadOnly(); }
        public int Capacity { get => capacity; }

        public void Add(ITeam model)
        {
            if(this.models.Count<Capacity) this.models.Add(model);
        }

        public bool Remove(string name)
        {
            ITeam teamToRemove=this.models.FirstOrDefault(x => x.Name == name);
            if(teamToRemove==null) return false;
            return this.models.Remove(teamToRemove);
        }

        public bool Exists(string name)
        {
            ITeam teamToFind = this.models.FirstOrDefault(x => x.Name == name);
            if (teamToFind == null) return false;
            return true;

        }

        public ITeam Get(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

      
    }
}
