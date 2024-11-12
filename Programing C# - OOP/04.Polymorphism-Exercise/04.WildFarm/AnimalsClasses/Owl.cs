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
        public override void ProduceSoundForFood(Food food)
        {
            Console.WriteLine("Hoot Hoot");
            string foodType = food.GetType().Name;
            if (foodType.ToUpper() == "MEAT")
            {
                this.Weight += (this.IndividualIncrese * food.Quantity);
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name.ToString()} does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name.ToString()} "+base.ToString();
        }
    }
}
