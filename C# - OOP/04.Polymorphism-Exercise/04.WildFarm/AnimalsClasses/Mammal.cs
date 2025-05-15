using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }

        public override double IndividualIncrese { get; }

        public override string Sound { get; }
        public override IReadOnlyCollection<string> PrefferFoods { get; }


        public override string ToString() => $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
