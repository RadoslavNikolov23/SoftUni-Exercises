using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(" ");
          //  input.Reverse();

            Stack<string> stackST = new Stack<string>();

            for (int i = input.Length-1; i >=0; i--)
            {
                stackST.Push(input[i]);
            }

            int result = int.Parse(stackST.Pop());
            
            while (true)
            {
                string symbol = stackST.Pop();
                int numberTwo = int.Parse(stackST.Pop());
              

                if (symbol == "+")
                {
                    result+=numberTwo;
                }
                else if (symbol == "-")
                {
                    result-=numberTwo;
                }

                if (stackST.Count() == 0)
                {
                    break;
                }

            }
            Console.WriteLine(result);
        }
    }
}
