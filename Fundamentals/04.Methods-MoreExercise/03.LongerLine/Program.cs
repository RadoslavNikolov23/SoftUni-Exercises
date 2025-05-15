using System;
using System.Collections.Generic;

namespace _03.LongerLine
{

    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            
            double a1 = double.Parse(Console.ReadLine());
            double b1 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());


            double resultXY = GetResult(x1, y1, x2, y2);
            double resultAB = GetResult(a1, b1, a2, b2);

            if (resultXY >= resultAB)
            {
                ClosesToCenter(x1, y1, x2, y2);
            }
            else
            {
                ClosesToCenter(a1, b1, a2, b2);

            }

        }

        private static void ClosesToCenter(double x1, double y1, double x2, double y2)
        {
            double firstPair = Math.Sqrt(Math.Pow(Math.Abs(x1), 2) + Math.Pow(Math.Abs(y1), 2));
            double secondPair = Math.Sqrt(Math.Pow(Math.Abs(x2), 2) + Math.Pow(Math.Abs(y2), 2));
            if (firstPair > secondPair)
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }

        }

        private static double GetResult(double x1, double y1, double x2, double y2)
        {
            double result = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));


            return result;
        }
    }
}
