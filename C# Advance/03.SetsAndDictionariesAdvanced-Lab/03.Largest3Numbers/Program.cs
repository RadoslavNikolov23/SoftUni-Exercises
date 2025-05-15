﻿namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> biggestThree=numbers.OrderByDescending(x => x).Take(3).ToList();

            Console.WriteLine(string.Join(" ",biggestThree));


        }
    }
}
