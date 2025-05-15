using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();
            Stack<char> stackCH = new Stack<char>();
            bool isBalaned = false;

            for(int i = 0; i < textInput.Length; i++)
            {
                char tempCH = textInput[i];

                if (tempCH == '(')
                {
                    stackCH.Push(')');
                }
                else if (tempCH == '{')
                {
                    stackCH.Push('}');
                } 
                else if (tempCH == '[')
                {
                    stackCH.Push(']');
                }
                else
                {
                    if(stackCH.Count>0 && stackCH.Peek() == tempCH)
                    {
                        stackCH.Pop();
                        isBalaned = true;
                    }
                    else
                    {
                        isBalaned = false;
                        break;
                    }

                }
            }
            if (isBalaned)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
