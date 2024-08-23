using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

namespace _05.ShoppingSpree
{
    internal class Program
    {

       class Person
       {
           public Person(string name, decimal money)
           {
               Name = name;
               Money = money;
           }

           public void PersonList(string products)
           {
               Products.Add(products);

            }

            public string Name { get; set; }
           public decimal Money { get; set; }
           public List<string> Products { get; set; }= new List<string>();
       }

       class Product
       {
           public Product(string name, decimal cost)
           {
               Name = name;
               Cost = cost;
           }

           public string Name { get; set; }

           public decimal Cost { get; set; }
       }
        static void Main(string[] args)
        {

            Dictionary<string,Person> personList=new Dictionary<string,Person>();
            Dictionary<string,Product> productList=new Dictionary<string,Product>();


            string[] arrayNames = Console.ReadLine().Split(new char[]{'=',';'},StringSplitOptions.RemoveEmptyEntries);


            string[] arrayProducts = Console.ReadLine().Split(new char[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries);
      

            int number = 0;
            for (int i = 0; i < arrayNames.Length/2; i++)
            {
                
                string name = arrayNames[number];
                decimal amoundMoney = decimal.Parse(arrayNames[number+1]);

                personList.Add(name,(new Person(name,amoundMoney)));
                number += 2;
            }

            number = 0;
            for (int i = 0; i < arrayProducts.Length / 2; i++)
            {

                string productName = arrayProducts[number];
                decimal productCost = decimal.Parse(arrayProducts[number+1]);

                productList.Add(productName,(new Product(productName,productCost)));
                number += 2;
            }


            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                
                string[] arrayBuy = input.Split();
                string name=arrayBuy[0];
                string productName=arrayBuy[1];
                
                if (personList[name].Money >= productList[productName].Cost)
                {
                    personList[name].Products.Add(productName);
                    personList[name].Money-=productList[productName].Cost;
                    Console.WriteLine($"{name} bought {productName}");

                }
                else
                {
                    Console.WriteLine($"{name} can't afford {productName}");
                }
              

            }

            foreach (var person in personList)
            {
                if (person.Value.Products.Count > 0)
                {
                    
                    Console.WriteLine($"{person.Value.Name} - {string.Join(", ", person.Value.Products)}");
                }
                else
                {
                    Console.WriteLine($"{person.Value.Name} - Nothing bought");

                }
            }
           
        }
    }
}
