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


        public override void ProduceSoundForFood(Food food)
        {
            Console.WriteLine("ROAR!!!");
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
            return $"{GetType().Name.ToString()} " + base.ToString();

        }
    }
}
