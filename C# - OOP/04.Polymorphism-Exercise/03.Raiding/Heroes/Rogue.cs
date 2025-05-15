using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Heroes
{
    public class Rogue : BaseHero
    {
        private const int powerRogue = 80;
        public Rogue(string name) : base(name, powerRogue)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name.ToString()} - {this.Name} hit for {this.Power} damage";
        }
    }
}
