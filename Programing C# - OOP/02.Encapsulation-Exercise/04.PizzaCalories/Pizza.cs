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
        private List<Toppings> _toppingsPizza=new List<Toppings>();
        private Dough _doughtPizza;
        
        public Pizza(string namePizza,Dough dough)
        {
            this.NamePizza = namePizza;
            this.DoughtPizza = dough;
        }



        public string NamePizza { get=>_namePizza;

            private set 
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length>15) throw new ArgumentNullException("Pizza name should be between 1 and 15 symbols.");
                _namePizza = value;
            }
        }
        public IReadOnlyCollection<Toppings> ToppingsPizza { get => this._toppingsPizza.AsReadOnly(); }
        public int NumberToppings { get => this._toppingsPizza.Count(); }
        public Dough DoughtPizza { get; set; }

        public double TotalCalories
        {
            get=> TotalCaloriesMethod();
        }

        public double TotalCaloriesMethod()
        {
            return this._toppingsPizza.Sum(x => x.CalculateCalories()) + this.DoughtPizza.CalculateCalories();
        }

        public void AddToppings(Toppings topping)
        {

            if (this.NumberToppings == 10) throw new ArgumentException("Number of toppings should be in range [0..10].");

            this._toppingsPizza.Add(topping);

        }

        public override string ToString()
        {
            return $"{this.NamePizza} - {this.TotalCalories:f2} Calories.";
        }
    }
}
