using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stackST = new Stack<string>();
            StringBuilder sbTemp = new StringBuilder();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] array = Console.ReadLine().Split();
                string firstCommand = array[0];

                if (firstCommand == "1")
                {
                    stackST.Push(sbTemp.ToString());
                    sbTemp.Append(array[1]);

                }
                else if (firstCommand == "2")
                {
                    int counterToErase = int.Parse(array[1]);
                    stackST.Push(sbTemp.ToString());
                    sbTemp.Remove(sbTemp.Length - counterToErase, counterToErase);
                   
                }
                else if (firstCommand == "3")
                {
                    int indexToReturn = int.Parse(array[1]) - 1;
                    Console.WriteLine($"{sbTemp[indexToReturn]}");
                  
                }
                else if (firstCommand == "4")
                {
                    sbTemp.Clear();
                   sbTemp.Append( stackST.Pop());
                }

            }


        }
    }
}
