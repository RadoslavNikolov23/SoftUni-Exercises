using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private readonly List<Product> products;

        public Person(string name, double money)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");
            if (money < 0) throw new ArgumentException("Money cannot be negative");

            this.Name = name;
            this.Money = money;

            this.products = new List<Product>();
            this.Products = this.products.AsReadOnly();
        }



        public IReadOnlyCollection<Product> Products { get; set; }
        public string Name { get; private set; }

        public double Money { get; set; }

        public bool CanAfford(Product product)
        {
            double leftMoney = this.Money - product.Cost;
            if (leftMoney < 0) return false;

            this.Money -= product.Cost;
            this.products.Add(product);
            return true;
        }

    }
}
