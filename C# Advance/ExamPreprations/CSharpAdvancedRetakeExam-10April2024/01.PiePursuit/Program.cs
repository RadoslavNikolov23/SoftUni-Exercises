using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.PiePursuit
{
    public class Program
    {
        public static void Main()
        {
            Queue<int> contestants = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> pies = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (contestants.Count > 0 && pies.Count > 0)
            {
                int firstContestant = contestants.Dequeue();
                int lastPie = pies.Pop();

                if (firstContestant >= lastPie)
                {
                    firstContestant -= lastPie;
                    if (firstContestant == 0) continue;

                    contestants.Enqueue(firstContestant);
                }
                else
                {
                    lastPie -= firstContestant;
                    if (lastPie <= 1)
                    {
                        if (pies.Count == 0) pies.Push(lastPie);
                        else pies.Push(pies.Pop() + lastPie);
                    }
                    else pies.Push(lastPie);
                }

            }

            if (pies.Count == 0 && contestants.Count == 0)
            {
                Console.WriteLine($"We have a champion!");
            }
            else if (pies.Count == 0 && contestants.Count != 0)
            {
                Console.WriteLine($"We will have to wait for more pies to be baked!");
                Console.WriteLine($"Contestants left: {string.Join(", ", contestants)}");
            }
            else if (pies.Count != 0 && contestants.Count == 0)
            {
                Console.WriteLine($"Our contestants need to rest!");
                Console.WriteLine($"Pies left: {string.Join(", ", pies)}");

            }
        }
    }
}
