using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAxeAndDummy.Interfaces
{
    public interface IHero
    {
        public string Name { get; }
        public int Experience { get; set; }
        public IWeapon Weapon { get; }

        public void Attack(ITarget target);

    }
}
