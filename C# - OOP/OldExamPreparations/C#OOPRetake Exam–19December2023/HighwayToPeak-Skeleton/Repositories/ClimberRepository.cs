using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : Repository<IClimber>
    {
        public override IClimber Get(string name)
        {
            return this.all.FirstOrDefault(p => p.Name == name);
        }
    }
}
