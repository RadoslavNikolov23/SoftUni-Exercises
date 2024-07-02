using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> newList = new List<int>();
            


            for (int i = 0; i < list.Count / 2; i++)
            {
               // int n = list.Count - 1 - i;
                newList.Add(list[i] + list[list.Count - 1 - i]);
            }

            if (list.Count % 2 == 1)
            {
                newList.Add(list[list.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", newList));

        }
    }
}
