using System;
//using System.Linq;
//using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _01.Furniture
{
    class Program
    {
        class Product
        {
            public string FurnitureName;
            public double Price;
            public double Quantity;

            public Product(string furnitureName, double price, double quantity)
            {
                FurnitureName = furnitureName;
                Price = price;
                Quantity = quantity;
            }

            public double Total
            {
                get { return Price * Quantity; }
            }

         
        }
        static void Main(string[] args)
        {
            string input;
            string pattern = @"\>\>(?<FurnitureName>[A-Za-z]+)\<\<(?<Price>\d+|\d+\.\d+)\!(?<Quantity>\d+)";

            List<Product> productsDict = new List<Product>();
            double allAmount = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                foreach (Match product in Regex.Matches(input, pattern))
                {
                    productsDict.Add(new Product(
                        product.Groups["FurnitureName"].Value,
                        double.Parse(product.Groups["Price"].Value),
                        double.Parse(product.Groups["Quantity"].Value)));
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (var product in productsDict)
            {
                Console.WriteLine(product.FurnitureName);
                allAmount += product.Total;
            }
            Console.WriteLine($"Total money spend: {allAmount:f2}");

        }
    }
}
