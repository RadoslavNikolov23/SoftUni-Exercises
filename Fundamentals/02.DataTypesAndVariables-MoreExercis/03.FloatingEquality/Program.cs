using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
           // string[] numbers = Console.ReadLine().Split();
            double leftNumber = double.Parse(Console.ReadLine());
            double rightNumber = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            double diffrence;

            if (leftNumber > rightNumber)
            {
                diffrence = leftNumber - rightNumber;
            }
            else
            {
                diffrence = rightNumber - leftNumber;
            }

            if (eps > diffrence)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

        }
    }
}
