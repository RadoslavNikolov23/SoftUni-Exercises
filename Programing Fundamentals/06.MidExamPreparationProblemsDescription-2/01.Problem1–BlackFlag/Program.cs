using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Problem1_BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int plunber = int.Parse(Console.ReadLine());
            int expectedPlunder = int.Parse(Console.ReadLine());
            double sumPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                sumPlunder += plunber;

                if (i % 3 == 0)
                {
                    sumPlunder += plunber * 0.5;
                }

                if (i % 5 == 0)
                {
                    sumPlunder -= sumPlunder * 30 / 100;
                }
            }
       
            if (sumPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {sumPlunder:f2} plunder gained.");
            }
            else
            {
                double percetange = sumPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percetange:f2}% of the plunder.");
            }


        }
    }
}
