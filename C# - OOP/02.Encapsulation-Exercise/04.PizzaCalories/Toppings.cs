using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Toppings
    {
        public Toppings(string toppingTypes, double grams)
        {
            this.ToppingTypes = toppingTypes;
            this.Grams = grams;
        }

        private string _toppingTypes;
        private double _grams;

        private string ToppingTypes
        {
            get => _toppingTypes;
            set
            {

                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce") _toppingTypes = value;
                else throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }

        private double Grams
        {
            get => _grams;
            set
            {
                if (value < 1 || value > 50) throw new ArgumentException($"{this._toppingTypes} weight should be in the range [1..50].");
                else _grams = value;

            }
        }

        private double Modifiers(string typeTopping)
        {
            switch (typeTopping.ToLower())
            {
                case "meat":
                    return 1.2;
                    break;
                case "veggies":
                    return 0.8;
                    break;
                case "cheese":
                    return 1.1;
                    break;
                case "sauce":
                    return 0.9;
                    break;
                default:
                    return 1.0;
                    break;
            }
        }

        public double CalculateCaloriesToppings => 2 * Grams * Modifiers(this.ToppingTypes);


    }

}
