using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Problem1_CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input;
            int coutWins = 0;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {coutWins} won battles and {energy} energy");
                    break;
                }

                energy -= distance;
                coutWins++;

                if (coutWins % 3 == 0)
                {
                    energy += coutWins;
                }
                if (energy < 0)
                {
                    break;
                }
            }

            if (input == "End of battle")
            {
                Console.WriteLine($"Won battles: {coutWins}. Energy left: {energy}");
            }




        }
    }
}
