using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {

        public Dough(string flour, string bakingTechique, double grams)
        {
            this.Flour = flour;
            this.BakingTechique = bakingTechique;
            this.Grams = grams;
        }

        private string _flour;
        private string _bakingTechique;
        private double _grams;

        private string Flour
        {
            get => _flour;
            set
            {

                if (value == "white" || value == "wholegrain") _flour = value;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }
        private string BakingTechique
        {
            get => _bakingTechique;
            set
            {
                if (value.ToLower()== "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade") _bakingTechique = value;
                else throw new ArgumentException("Invalid type of dough.");
            }
        }

        private double Grams
        {
            get => _grams;
            set
            {
                if (value < 1 || value > 200) throw new ArgumentException("Dough weight should be in the range [1..200].");
                else _grams = value;
            }
        }

        private double Modifiers(string types)
        {
            switch (types.ToLower())
            {
                case "white":
                    return 1.5;
                    break;
                case "wholegrain":
                    return 1.0;
                    break;
                case "crispy":
                    return 0.9;
                    break;
                case "chewy":
                    return 1.1;
                    break;
                case "homemade":
                    return 1.0;
                    break;
                default:
                    return 0.0;
                    break;
            }
        }

        public double CalculateCaloriesDought => (2 * this.Grams) * Modifiers(this.Flour) * Modifiers(this.BakingTechique);


    }
}
