using System;
using System.Linq;
using System.Collections.Generic;
namespace _02.Problem2_ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input;
            int counter = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < array.Length)
                {
                    if (array[index] != -1)
                    {
                        int tempValue = array[index];
                        array[index] = -1;
                        counter++;
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] != -1)
                            {
                                if (array[i] > tempValue)
                                {
                                    array[i] -= tempValue;
                                }
                                else
                                {
                                    array[i] += tempValue;
                                }
                            }

                        }
                    }
                }

               
            }
            Console.WriteLine($"Shot targets: { counter} -> {string.Join(" ", array)}");




        }
    }
}
