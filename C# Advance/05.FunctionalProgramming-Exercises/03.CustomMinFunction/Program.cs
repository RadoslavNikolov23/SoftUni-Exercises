using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Func<int[], int> findSmallestNumber = FindSmallestNumberMethod;

            Console.WriteLine(findSmallestNumber(numbers));

            //Alternative:
            /*Func<int[], int> findSmallestNumbers = n=>n.Min();
            Console.WriteLine(findSmallestNumbers(numbers));
            */


             int FindSmallestNumberMethod(int[] numbers)
            {
                int smallestNumber = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < smallestNumber)
                        smallestNumber = number;
                }

                return smallestNumber;
            }
        }
    }
}
