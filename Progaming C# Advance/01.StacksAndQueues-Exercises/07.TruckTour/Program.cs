using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPetrolPumps = int.Parse(Console.ReadLine());
            Queue<int> amountQU = new Queue<int>();
            Queue<int> distanceQU = new Queue<int>();

            for (int i = 0; i < numberOfPetrolPumps; i++)
            {
                int[] pair = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                int amountOfPetrol = pair[0];
                int distanceOfKilom = pair[1];
                amountQU.Enqueue(amountOfPetrol);
                distanceQU.Enqueue(distanceOfKilom);
            }

            int indexStart = 0;
            int currIndex = 0;
            int fuel = amountQU.Peek();
            int counterPetrolStation = 0;

            while (numberOfPetrolPumps >= counterPetrolStation)
            {
                if (counterPetrolStation == 0)
                {
                    indexStart = currIndex;
                }

                if (fuel >= distanceQU.Peek())
                {
                  
                    fuel -= distanceQU.Peek();
                    counterPetrolStation++;
                    amountQU.Enqueue(amountQU.Dequeue());
                    distanceQU.Enqueue(distanceQU.Dequeue());
                    fuel += amountQU.Peek();
                }
                else
                {
                    amountQU.Enqueue(amountQU.Dequeue());
                    distanceQU.Enqueue(distanceQU.Dequeue());
                    fuel = amountQU.Peek();
                    counterPetrolStation = 0;
                }
                currIndex++;
            }
            Console.WriteLine(indexStart);

        }
    }

}
