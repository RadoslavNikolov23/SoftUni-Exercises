using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override double IndividualIncrese { get => 0.10; }
        public override string Sound { get => "Squeak"; }
        public override IReadOnlyCollection<string> PrefferFoods { get => new List<string>() { "Vegetable", "Fruit" }.AsReadOnly(); }

        public override string ToString() => $"{GetType().Name.ToString()} [{this.Name}, " + base.ToString();
    }
}
