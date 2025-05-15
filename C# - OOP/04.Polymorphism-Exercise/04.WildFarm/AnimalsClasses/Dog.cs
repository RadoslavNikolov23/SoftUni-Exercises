using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override double IndividualIncrese { get => 0.40; }
        public override string Sound { get => "Woof!"; }
        public override IReadOnlyCollection<string> PrefferFoods { get => new List<string>() { "Meat" }.AsReadOnly(); }

        public override string ToString() => $"{GetType().Name.ToString()} [{this.Name}, " + base.ToString();
    }
}
