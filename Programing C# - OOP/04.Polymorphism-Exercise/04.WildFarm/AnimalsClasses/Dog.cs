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


        public override void ProduceSoundForFood(Food food)
        {
            Console.WriteLine("Woof!");
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
            return $"{GetType().Name.ToString()} [{this.Name}, " + base.ToString();
           
        }
    }
}
