using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : Repository<IPeak>
    {
        public override IPeak Get(string name)
        {
            return this.all.FirstOrDefault(p=>p.Name==name);
        }
    }
}
