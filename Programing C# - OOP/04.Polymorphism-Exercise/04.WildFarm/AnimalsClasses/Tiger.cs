using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double IndividualIncrese { get => 1.00; }
        public override string Sound { get => "ROAR!!!"; }
        public override IReadOnlyCollection<string> PrefferFoods { get => new List<string>() { "Meat" }.AsReadOnly(); }
        public override string ToString() => $"{GetType().Name.ToString()} " + base.ToString();
    }
}
