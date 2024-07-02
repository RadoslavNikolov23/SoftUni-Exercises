using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace _02.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);




        }
    }
}
