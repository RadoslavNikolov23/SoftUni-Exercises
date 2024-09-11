using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = numbers[0], s = numbers[1], x = numbers[2];

            int[] numberToInput= Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queueNumbers = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queueNumbers.Enqueue(numberToInput[i]);
            } 
            for (int i = 0; i < s; i++)
            {
                queueNumbers.Dequeue();
            }

            if (queueNumbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                bool isMatch = false;
                int minNumber = int.MaxValue;
                while (queueNumbers.Count > 0)
                {
                    int tempNumber = queueNumbers.Dequeue();

                    if (tempNumber == x)
                    {
                        isMatch = true;
                    }
                    if (tempNumber < minNumber)
                    {
                        minNumber = tempNumber;
                    }

                }

                if(isMatch)
                    Console.WriteLine("true");
                else
                    Console.WriteLine(minNumber);
            }

        }
    }
}
