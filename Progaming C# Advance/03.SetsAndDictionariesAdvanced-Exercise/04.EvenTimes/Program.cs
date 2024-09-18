using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersRow = int.Parse(Console.ReadLine());
            Dictionary<int,int> numbersDictionary = new Dictionary<int, int>();

            for(int i = 0; i < numbersRow; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersDictionary.ContainsKey(number))
                {
                    numbersDictionary.Add(number,0);
                    numbersDictionary[number]++;
                }
                else
                {
                    numbersDictionary[number]++;
                }
            }

            // First variant:
                /*int maxKey = 0;
                foreach (var number in numbersDictionary.OrderByDescending(x => x.Value))
                {
                    if (number.Value % 2 == 0)
                    {
                        maxKey = number.Key;
                        break;
                    }
                }

                Console.WriteLine(maxKey);
                */

            //Second variant:
            Console.WriteLine(string.Join(" ", numbersDictionary.OrderByDescending(x => x.Value)
                .Where(x=>x.Value%2==0).Take(1).Select(x=>x.Key)));
        }
    }
}
