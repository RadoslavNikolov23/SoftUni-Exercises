using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string _namePizza;
        private List<Toppings> _toppingsPizza;
        private Dough _doughtPizza;
        
        public Pizza(string namePizza)
        {
            this.NamePizza = namePizza;
            this._toppingsPizza=new List<Toppings>();
            this.ToppingsPizza = this._toppingsPizza.AsReadOnly();
        }



        public string NamePizza { get=>_namePizza;

            private set 
            {
                if(string.IsNullOrEmpty(value) || value.Length<1 || value.Length>15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                else _namePizza = value;
            }
        }
        public IReadOnlyCollection<Toppings> ToppingsPizza { get; }
        public int NumberToppings { get => this._toppingsPizza.Count(); }
        public Dough DoughtPizza { get; set; }

        public double TotalCalories => this._toppingsPizza.Sum(x => x.CalculateCaloriesToppings) + this.DoughtPizza.CalculateCaloriesDought;
     

        public void AddToppings(Toppings topping)
        {

            if (this.NumberToppings >= 10) throw new ArgumentException("Number of toppings should be in range [0..10].");

            this._toppingsPizza.Add(topping);

        }

        public override string ToString()
        {
            return $"{this.NamePizza} - {this.TotalCalories:f2} Calories.";
        }
    }
}
