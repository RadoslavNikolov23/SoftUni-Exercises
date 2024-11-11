using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Heroes
{
    public class Paladin : BaseHero
    {
        private const int powerPaladin = 100;
        public Paladin(string name) : base(name, powerPaladin)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name.ToString()} - {this.Name} healed for {this.Power}";
        }
    }
}
