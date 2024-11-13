using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; }
        public override double IndividualIncrese { get; }

        public override string Sound { get; }
        public override IReadOnlyCollection<string> PrefferFoods { get; }

 

        public override string ToString() => $"[{this.Name}, {WingSize}, {this.Weight}, {this.FoodEaten}]";


    }
}
