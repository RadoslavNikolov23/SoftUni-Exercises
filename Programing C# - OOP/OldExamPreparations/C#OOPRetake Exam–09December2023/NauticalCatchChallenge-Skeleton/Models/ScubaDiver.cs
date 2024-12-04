using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int oxygenLevelScubaDiver = 540;

        public ScubaDiver(string name) : base(name, oxygenLevelScubaDiver)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)(TimeToCatch * 0.30);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = oxygenLevelScubaDiver;

        }
    }
}
