using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stackST = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                string tempCh = input[i].ToString();
                

                if (tempCh == "(")
                {
                    stackST.Push(i);
                }

                if (tempCh == ")")
                {
                    int starIndex = stackST.Pop();
                    string temp = input.Substring(starIndex, i - starIndex + 1);
                    Console.WriteLine(temp);
                }
            }
        }
    }
}
