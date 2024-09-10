using System;
using System.Collections.Generic;

namespace _01.ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stackST = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stackST.Push(input[i]);
            }

            Console.Write(string.Join("",stackST));
            
        }
    }
}
