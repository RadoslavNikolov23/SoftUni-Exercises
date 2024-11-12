using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.FoodClasses;

namespace WildFarm.AnimalsClasses
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override double IndividualIncrese { get => 0.10; }


        public override void ProduceSoundForFood(Food food)
        {
            Console.WriteLine("Squeak");

            string foodType=food.GetType().Name;
            if(foodType.ToUpper()=="VEGETABLE" || foodType.ToUpper() == "FRUIT")
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
