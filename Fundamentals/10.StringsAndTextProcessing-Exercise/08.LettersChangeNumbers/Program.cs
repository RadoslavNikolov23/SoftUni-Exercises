using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] worldArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            decimal finalSum = 0;

            foreach (var word in worldArray)
            {
                char firstLetter = word[0];
                char lastLetter = word[word.Length-1];
                decimal number = decimal.Parse(word.Substring(1, word.Length - 2));
                decimal curruntSum = 0;

                if (char.IsUpper(firstLetter))
                {
                    curruntSum = number / (firstLetter - 'A'+1);
                }
                else if (char.IsLower(firstLetter))
                {
                    curruntSum = number * (firstLetter - 'a' + 1);
                }

                if (char.IsUpper(lastLetter))
                {
                    curruntSum -= (lastLetter - 'A' + 1);
                }
                else if (char.IsLower(lastLetter))
                {
                    curruntSum += (lastLetter - 'a' + 1);

                }

                finalSum += curruntSum;

            }
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
