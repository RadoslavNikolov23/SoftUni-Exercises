using System;
using System.Linq;
using System.Collections.Generic;


namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charCounterDict = new Dictionary<char, int>();

            string[] array = Console.ReadLine().Split();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    char temp = array[i][j];
                    if (!charCounterDict.ContainsKey(temp))
                    {
                        charCounterDict.Add(temp, 0);
                    }
                    charCounterDict[temp]++;
                }
            }
            foreach (var charet in charCounterDict)
            {
                Console.WriteLine($"{charet.Key} -> {charet.Value}");
            }


        }
    }
}
