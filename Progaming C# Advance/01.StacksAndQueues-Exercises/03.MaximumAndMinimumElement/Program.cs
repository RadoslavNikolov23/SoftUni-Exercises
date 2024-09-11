using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfEntries = int.Parse(Console.ReadLine());

            Stack<int> stackNumber = new Stack<int>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int tempNumber = array[0];

                switch (tempNumber)
                {
                    case 1:
                        stackNumber.Push(array[1]);
                        break;
                    case 2:
                        stackNumber.Pop();
                        break;
                    case 3:
                        if (stackNumber.Count > 0)
                            Console.WriteLine($"{stackNumber.Max()}");
                        break;
                    case 4:
                        if (stackNumber.Count > 0)
                            Console.WriteLine($"{stackNumber.Min()}");
                        break;
                }
            }
                Console.WriteLine(string.Join(", ",stackNumber));
        }
    }
}
