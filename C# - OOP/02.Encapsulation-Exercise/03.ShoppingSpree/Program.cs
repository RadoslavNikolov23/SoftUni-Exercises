using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree;

public class Program
{
    public static void Main()
    {
        try
        {
            Person[] persons = ReadPerson();
            Product[] products = ReadProduct();

            Dictionary<string, Person> bags = new Dictionary<string, Person>();

            foreach (var person in persons) bags[person.Name] = person;


            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tempArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (bags[tempArray[0]].CanAfford(products.First(x => x.Name == tempArray[1])))
                {
                    Console.WriteLine($"{tempArray[0]} bought {tempArray[1]}");
                }
                else Console.WriteLine($"{tempArray[0]} can't afford {tempArray[1]}");

                input = Console.ReadLine();
            }

            PrintOutput(bags);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    private static void PrintOutput(Dictionary<string, Person> bags)
    {
        foreach (var person in bags)
        {
            Console.WriteLine(person.Value.Products.Count > 0
                ? $"{person.Key} - {string.Join(", ", person.Value.Products.Select(x=>x.Name))}"
                : $"{person.Key} - Nothing bought");
        }
    }

    public static Person[] ReadPerson()
    {
        string[] dataPerson = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
        Person[] persons = new Person[dataPerson.Length];

            for (int i = 0; i < dataPerson.Length; i++)
            {
                string[] tempArray = dataPerson[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                persons[i] = new Person(tempArray[0], double.Parse(tempArray[1]));
            }

        return persons;
    }

    public static Product[] ReadProduct()
    {
        string[] dataProduct = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
        Product[] products = new Product[dataProduct.Length];

        for (int i = 0; i < dataProduct.Length; i++)
        {
            string[] tempArray = dataProduct[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
            products[i] = new Product(tempArray[0], double.Parse(tempArray[1]));
        }

        return products;
    }
}
