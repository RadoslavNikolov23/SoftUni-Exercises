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
        private List<ITeam> team;

        public TeamRepository()
        {
            this.team = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models { get => this.team.AsReadOnly(); }
        public int Capacity { get => 10; }

        public void Add(ITeam model)
        {
            if(this.team.Count<Capacity) this.team.Add(model);
        }

        public bool Remove(string name)
        {
            ITeam teamToRemove=this.team.FirstOrDefault(x => x.Name == name);
            if(teamToRemove==null) return false;
            return this.team.Remove(teamToRemove);
        }

        public bool Exists(string name)
        {
            ITeam teamToFind = this.team.FirstOrDefault(x => x.Name == name);
            if (teamToFind == null) return false;
            return true;

        }

        public ITeam Get(string name)
        {
            return this.team.FirstOrDefault(x => x.Name == name);
        }

      
    }
}
