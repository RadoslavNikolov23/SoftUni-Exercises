using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int oxygenLevelFreeDiver = 120;
        public FreeDiver(string name) : base(name, oxygenLevelFreeDiver)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)(TimeToCatch * 0.60);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = oxygenLevelFreeDiver;
        }
    }
}
