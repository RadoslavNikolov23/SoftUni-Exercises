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


        public override void ProduceSoundForFood(Food food)
        {
            Console.WriteLine("Meow");
            string foodType = food.GetType().Name;
            if (foodType.ToUpper() == "MEAT" || foodType.ToUpper() == "VEGETABLE")
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
