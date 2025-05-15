using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> addSir = name =>
            {
                string sir = "Sir";
              //  foreach (var nam in name) Console.WriteLine(sir + " " + nam);
                Console.WriteLine(sir + " " + (string.Join($"\n{sir} ", names)));
            };

            addSir(names);
        }
    }
}
