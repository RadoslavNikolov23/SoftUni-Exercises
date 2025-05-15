using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models { get => this.models.AsReadOnly(); }

        public void AddModel(IPlayer model) => this.models.Add(model);

        public bool ExistsModel(string name) => this.models.Any(p => p.Name == name);

        public IPlayer GetModel(string name)=> this.models.FirstOrDefault(p => p.Name == name);
       
        public bool RemoveModel(string name)
        {
            IPlayer player = this.models.FirstOrDefault(p=>p.Name==name);
            return this.models.Remove(player);
        }
    }
}
