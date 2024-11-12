using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override double IndividualIncrese { get => 0.30; }
        public override string Sound { get => "Meow"; }
        public override IReadOnlyCollection<string> PrefferFoods { get => new List<string>() { "Vegetable", "Meat" }.AsReadOnly(); }
        public override string ToString() => $"{GetType().Name.ToString()} " + base.ToString();
    }
}
