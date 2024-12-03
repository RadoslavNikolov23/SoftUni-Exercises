using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int initialStaminaNC = 6;
        public NaturalClimber(string name) : base(name, initialStaminaNC)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += (daysCount*2);
        }
    }
    
}
