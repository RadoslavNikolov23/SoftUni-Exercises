using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberLines = long.Parse(Console.ReadLine());

            for (long i = 0; i < numberLines; i++)
            {
                string[] array = Console.ReadLine().Split(" ");
                long leftNumber = long.Parse(array[0]);
                long righttNumber = long.Parse(array[1]);

                if (leftNumber > righttNumber)
                {
                    long number = Math.Abs(leftNumber);
                    long sumNumbers = 0;
                    for (int j = 0; j < number;)
                    {
                        long lastDigit = number % 10;
                        sumNumbers += lastDigit;
                        number /= 10;
                    }
                    Console.WriteLine(Math.Abs(sumNumbers));
                }
                else 
                {
                    long number = Math.Abs(righttNumber);
                    long sumNumbers = 0;
                    for (int j = 0; j < number;)
                    {
                        long lastDigit = number % 10;
                        sumNumbers += lastDigit;
                        number /= 10;
                    }
                    Console.WriteLine(Math.Abs(sumNumbers));
                }


            }


        }
    }
}
