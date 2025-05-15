using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> listOfNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> isEnough = (name,legth) =>
              {
                  int sumAll = 0;
                  foreach (char c in name) sumAll += c;

                  if (sumAll >= legth)
                      return true;
                  else return false;
              };


            Console.WriteLine(string.Join(" ",listOfNames.FirstOrDefault(x=>isEnough(x,number))));
        }
    }
}
