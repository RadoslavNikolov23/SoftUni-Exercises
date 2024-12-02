using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : Repository<IInfluencer>
    {
        public override IInfluencer FindByName(string name)
        {
            return this.Models.FirstOrDefault(m => m.Username == name)!;
        }

    }
}
