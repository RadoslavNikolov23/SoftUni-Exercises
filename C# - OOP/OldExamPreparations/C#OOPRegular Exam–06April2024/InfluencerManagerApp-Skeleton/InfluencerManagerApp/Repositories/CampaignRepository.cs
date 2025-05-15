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
    public class CampaignRepository : Repository<ICampaign>
    {
        public override ICampaign FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Brand == name);
        }
    }
}
