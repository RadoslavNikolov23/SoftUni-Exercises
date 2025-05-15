using System;
using System.Collections.Generic;

namespace _06.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfname = int.Parse(Console.ReadLine());

            HashSet<string> nameSet = new HashSet<string>();

            for(int i = 0; i < numberOfname; i++)
            {
                nameSet.Add(Console.ReadLine());
            }

            foreach(var name in nameSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
