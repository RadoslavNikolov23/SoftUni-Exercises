using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> uniqueNames = new HashSet<string>();

            int number = int.Parse(Console.ReadLine());

            for(int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();

                if (!uniqueNames.Contains(input))
                {
                    uniqueNames.Add(input);
                }
            }
            Console.WriteLine(string.Join("\n",uniqueNames));
        }
    }
}
