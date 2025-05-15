using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Orders
{
    class Product
    {
        public string Name;
        public double Price;
        public double Quantity;

        public Product(string name, double price, double quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Name} -> {TotalPrice():f2}";
        }

        private object TotalPrice()
        {
            return Price * Quantity;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> orderDictionary = new Dictionary<string, Product>();
            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] array = input.Split();
                string nameProduct = array[0];
                double priceProduct = double.Parse(array[1]);
                double quantityProduct = double.Parse(array[2]);
                Product product= new Product (nameProduct, priceProduct, quantityProduct);

                if (!orderDictionary.ContainsKey(nameProduct))
                {
                    orderDictionary.Add(nameProduct, product);
                }
                else
                {
                    orderDictionary[nameProduct].Price = priceProduct;
                    orderDictionary[nameProduct].Quantity += quantityProduct;
                }

            }

            foreach (var item in orderDictionary.Values)
            {
                Console.WriteLine(item);

            }

        }
    }
}
