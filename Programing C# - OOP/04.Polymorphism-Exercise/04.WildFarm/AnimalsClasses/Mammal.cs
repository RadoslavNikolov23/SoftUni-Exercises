using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       
        public override string ToString()
        {
        
            return $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
