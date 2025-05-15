using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] orderArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> orderQU = new Queue<int>(orderArray);


            int maxOrder = orderQU.Max();

            Console.WriteLine(maxOrder);


            while (true)
            {
                int order = orderQU.Peek();

                if (quantityFood >= order)
                {
                    quantityFood -= order;
                    orderQU.Dequeue();

                    if (orderQU.Count == 0)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }

            if (orderQU.Count == 0)
            {
                Console.WriteLine("Orders complete");

            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orderQU)}");
            }


        }
    }
}
