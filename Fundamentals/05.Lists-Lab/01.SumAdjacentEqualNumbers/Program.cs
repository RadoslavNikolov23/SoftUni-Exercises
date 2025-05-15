using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<double> list = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 0; i <= list.Count-2; i++)
            {

                if (list[i] == list[i + 1])
                {
                    list[i] = list[i] + list[i + 1];
                    list.RemoveAt(i+1);
                    i=-1;
                }



            }
            Console.WriteLine(String.Join(" ", list));


        }
    }
}
