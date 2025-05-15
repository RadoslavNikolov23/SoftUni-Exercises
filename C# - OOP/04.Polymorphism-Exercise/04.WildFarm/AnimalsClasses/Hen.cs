using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double IndividualIncrese { get => 0.35; }

        public override string Sound { get => "Cluck"; }
        public override IReadOnlyCollection<string> PrefferFoods { get => new List<string>() { "Meat", "Fruit", "Seeds", "Vegetable" }.AsReadOnly(); }

        public override string ToString() => $"{GetType().Name.ToString()} " + base.ToString();
    }
}
