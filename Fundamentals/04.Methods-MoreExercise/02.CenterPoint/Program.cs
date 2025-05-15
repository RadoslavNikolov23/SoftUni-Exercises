using System;

namespace _02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double radius = FindCPRadius(x1, y1);
            double radius2 = FindCPRadius(x2, y2);

            if (radius > radius2)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");

            }


        }

        private static double FindCPRadius(double x, double y)
        {

            double radious = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return radious;
        }
    }
}
