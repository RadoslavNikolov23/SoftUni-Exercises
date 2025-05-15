using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrintTheNumbersCoutnAndTheirSum(Console.ReadLine()
                  .Split(',', StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse).ToArray()));
        }

        public static string PrintTheNumbersCoutnAndTheirSum(int[] array)
        {
            return $"{array.Length}\n{array.Sum()}";
        }
    }
}
