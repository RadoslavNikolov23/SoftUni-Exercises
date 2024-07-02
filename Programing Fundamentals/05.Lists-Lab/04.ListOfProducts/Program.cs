using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            List<string> list = new List<string>(number);

            for (int i = 0; i < number; i++)
            {
                list.Add(Console.ReadLine());
            }

            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}.{list[i]}");

            }


        }
    }
}
