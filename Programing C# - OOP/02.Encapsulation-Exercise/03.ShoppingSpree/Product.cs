using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Product
    {

        private string name;

        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public double Cost
        {
            get => cost; 
            private set
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");
                cost = value;
            }
        }
    }
}
