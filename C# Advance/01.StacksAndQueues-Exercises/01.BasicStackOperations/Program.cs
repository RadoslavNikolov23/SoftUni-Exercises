using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = numbers[0], s = numbers[1], x = numbers[2];

            int[] numbersToStack = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stackNumbers = new Stack<int>();

            for(int i = 0; i < n; i++)
            {
                stackNumbers.Push(numbersToStack[i]);
            }

            for(int i = 0; i < s; i++)
            {
                stackNumbers.Pop();
            }

            if (stackNumbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if(stackNumbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stackNumbers.Min());
            }


        }
    }
}
