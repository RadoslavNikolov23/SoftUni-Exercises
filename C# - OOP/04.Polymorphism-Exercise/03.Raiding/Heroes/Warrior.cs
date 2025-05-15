using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Heroes
{
    public class Warrior : BaseHero
    {
        private const int powerWarrior = 100;
        public Warrior(string name) : base(name, powerWarrior)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name.ToString()} - {this.Name} hit for {this.Power} damage";
        }
    }
}
