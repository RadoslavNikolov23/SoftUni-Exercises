using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleLetters(input);
   

        }

        private static void PrintMiddleLetters(string input)
        {
            int middLetterNum;
            if (input.Length % 2 == 0)
            {
                middLetterNum = input.Length / 2;
                char newInput = input[middLetterNum];
                char newInputSecond = input[middLetterNum - 1];

                Console.WriteLine($"{newInputSecond}{newInput}");
                
            }
            else
            {
                middLetterNum = input.Length / 2;
                char newInput = input[middLetterNum];

                Console.WriteLine(newInput);
               

            }
             
           
        }
    }
}
