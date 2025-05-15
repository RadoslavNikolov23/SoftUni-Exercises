using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carsQU = new Queue<string>();
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());
            string input;
            int counterSafePassCars = 0;
            bool crashHappen = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int greenCycle = greenLightSeconds;

                    while (carsQU.Count > 0 && greenCycle > 0)
                    {
                        string carEnt = carsQU.Peek();


                        if (greenCycle >= carEnt.Length)
                        {
                            greenCycle -= carEnt.Length;
                            carsQU.Dequeue();
                            counterSafePassCars++;
                        }
                        else
                        {
                            if (greenCycle + freeWindowSeconds >= carEnt.Length)
                            {
                                carsQU.Dequeue();
                                greenCycle = 0;
                                counterSafePassCars++;
                            }
                            else
                            {
                                crashHappen = true;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carEnt} was hit at {carEnt[greenCycle + freeWindowSeconds]}.");
                                carsQU.Dequeue();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    carsQU.Enqueue(input);
                }

                if (crashHappen)
                {
                    break;
                }
            }

            if (!crashHappen)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counterSafePassCars} total cars passed the crossroads.");

            }

        }
    }
}
