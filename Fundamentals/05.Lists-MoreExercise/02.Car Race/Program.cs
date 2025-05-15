
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double leftDriver = 0;
            double rightDriver = 0;

            for (int i = 0; i < array.Length/2; i++)
            {
                if (array[i] == 0)
                {
                    leftDriver *= 0.8;
                }
                else
                {
                    leftDriver += array[i];
                }
            }

            for (int i = array.Length-1; i > array.Length/2; i--)
            {
                if (array[i] == 0)
                {
                    rightDriver *= 0.8;
                }
                else
                {
                    rightDriver += array[i];
                }

            }

            if (leftDriver > rightDriver)
            {
                if (rightDriver % 1 == 0)
                {
                    Console.WriteLine($"The winner is right with total time: {rightDriver:f0}");

                }
                else
                {
                    Console.WriteLine($"The winner is right with total time: {rightDriver:f1}");

                }
            }
            else
            {
                if (leftDriver % 1 == 0)
                {
                    Console.WriteLine($"The winner is left with total time: {leftDriver:f0}");
                }
                else
                {
                    Console.WriteLine($"The winner is left with total time: {leftDriver:f1}");

                }
            }

        }
    }
}
