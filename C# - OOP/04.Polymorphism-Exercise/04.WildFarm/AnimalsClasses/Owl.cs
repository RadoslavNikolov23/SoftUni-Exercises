using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double IndividualIncrese { get => 0.25; }

        public override string Sound { get => "Hoot Hoot"; }
        public override IReadOnlyCollection<string> PrefferFoods { get => new List<string>() { "Meat" }.AsReadOnly(); }


        public override string ToString() => $"{GetType().Name.ToString()} " + base.ToString();
    }
}
