using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsofElements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> nNumbers = new HashSet<int>(numbers[0]);
            HashSet<int> mNumbers = new HashSet<int>(numbers[1]);

            for(int i = 0; i < numbers[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                nNumbers.Add(number);
            } 
            
            for(int i = 0; i < numbers[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                mNumbers.Add(number);
            }

            List<int> uniqueNumbers = new List<int>();

            if (numbers[0] >= numbers[1])
            {
                foreach(var number in nNumbers)
                {
                    if (mNumbers.Contains(number))
                    {
                        uniqueNumbers.Add(number);
                    }
                }
            }
            else
            {
                foreach (var number in mNumbers)
                {
                    if (nNumbers.Contains(number))
                    {
                        uniqueNumbers.Add(number);
                    }
                }
            }

            Console.Write(string.Join(" ",uniqueNumbers));
        }
    }
}
