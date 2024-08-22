using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listNumbers = Console.ReadLine().Split().ToList();
            string inputText = Console.ReadLine();
            string message = string.Empty;

            for (int i = 0; i < listNumbers.Capacity; i++)
            {
                int sumOfDigits=0;
                for (int k = 0; k < listNumbers[i].Length; k++)
                {
                    int number= (int)char.GetNumericValue(listNumbers[i][k]);
                    sumOfDigits += number;
                }

                if (sumOfDigits >= inputText.Length)
                {
                    sumOfDigits -= inputText.Length;
                    char letter = inputText.ElementAt(sumOfDigits);
                    message += letter;
                    inputText = inputText.Remove(sumOfDigits, 1);

                }
                else
                {
                    char letter = inputText.ElementAt(sumOfDigits);
                    message += letter;
                    inputText = inputText.Remove(sumOfDigits, 1);
                }
            

            }
            Console.WriteLine(message);
        }
    }
}
