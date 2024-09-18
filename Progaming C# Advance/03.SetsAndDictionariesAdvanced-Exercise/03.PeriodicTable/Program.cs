using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {

            int countRows = int.Parse(Console.ReadLine());
            SortedSet<string> chemichalsSet = new SortedSet<string>();

            for(int i = 0; i < countRows; i++)
            {
                string[] chemicals = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicals.Length; j++)
                {
                    string tempChem = chemicals[j];
                    chemichalsSet.Add(tempChem);
                }
            }

            Console.Write(string.Join(" ",chemichalsSet));

        }
    }
}
