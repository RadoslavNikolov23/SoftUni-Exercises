using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",Console.ReadLine().Split(',',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Where(num=>num%2==0).OrderBy(num=>num)));


            /*
            List<int> numbersList = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> evenNumbersList = numbersList.Where(num => num % 2 == 0).Select(num => num).ToList();

            Console.WriteLine($"{string.Join(", ",evenNumbersList.OrderBy(num=>num))}");
            */

            // Alternative solution #2:
            /*
            List<int> numbersList = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> secondEvenList  = (from num in numbersList
                                         where num % 2 == 0
                                         select num).ToList();
            Console.WriteLine($"{string.Join(", ", secondEvenList.OrderBy(num => num))}");
            */
        }
    }
}
