using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            input = OnlyOneLetter(input);

            Console.WriteLine(input);
        }

        public static string OnlyOneLetter(string input)
        {
         
            char tempChar = input[0];
            string finalInput= tempChar.ToString();

            for (int i = 1; i < input.Length; i++)
            {
               
                if (tempChar == input[i])
                {
                    continue;
                }
                else
                {
                    tempChar = input[i];
                    finalInput+=tempChar;
                }
                
            }



            return finalInput;
        }
    }
}
