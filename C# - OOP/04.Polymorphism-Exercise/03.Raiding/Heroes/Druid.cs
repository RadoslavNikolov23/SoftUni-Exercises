using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Heroes
{
    public class Druid : BaseHero
    {
        private const int powerDriud = 80;
        public Druid(string name) : base(name, powerDriud)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name.ToString()} - {Name} healed for {Power}";
        }
    }
}
