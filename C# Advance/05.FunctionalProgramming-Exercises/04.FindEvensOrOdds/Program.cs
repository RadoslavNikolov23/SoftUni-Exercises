using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rangeMinMax = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string commandOddOrEven = Console.ReadLine();

            Predicate<int> isOddOrEven = x => commandOddOrEven == "even" ? x % 2 == 0 : x % 2 != 0;

            PrintOutPutOddOrEven(rangeMinMax, isOddOrEven, commandOddOrEven);
        }

        static void PrintOutPutOddOrEven(int[] rangeMinMax, Predicate<int> isOddOrEven, string commandOddOrEven)
        {
            for (int i = rangeMinMax[0]; i <= rangeMinMax[1]; i++)
            {
                if (isOddOrEven(i))
                    Console.Write(i + " ");
            }

        }
    }
}
