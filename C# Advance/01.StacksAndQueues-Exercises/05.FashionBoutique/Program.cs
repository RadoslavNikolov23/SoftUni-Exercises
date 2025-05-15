using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrayClothes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int capactyOfRack = int.Parse(Console.ReadLine());

            Stack<int> stackClothes = new Stack<int>(arrayClothes);
            int countRacks = 1;
            
            int currCapacity = 0;

            while (stackClothes.Count > 0)
            {
                int currOrder = stackClothes.Peek();

                if (capactyOfRack >= currCapacity+currOrder)
                {
                    currCapacity += currOrder;
                    stackClothes.Pop();
                }
                else
                {
                    countRacks++;
                    currCapacity = 0;
                    currCapacity += currOrder;
                    stackClothes.Pop();
                }

            }
            Console.WriteLine(countRacks);

        }
    }
}
