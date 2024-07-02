using System;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                int number = int.Parse(input);

                bool isPalindrome = ChechNumberForPalindrome(number);

                if (isPalindrome)
                {
                    Console.WriteLine(isPalindrome);
                }
                else
                {
                    Console.WriteLine(isPalindrome);
                }
            }

            //Create a program that reads positive integers until you receive the "END" command.
            //    For each number, print whether the number is a palindrome or not.
            //A palindrome is a number that reads the same backward as forward, such as 323 or 1001.

        }

        static bool ChechNumberForPalindrome(int number)
        {
            string numberString= number.ToString();
            string newRever = new string(numberString.Reverse().ToArray());
            int tempNumber = int.Parse(newRever);


            //char[] reverseNumberChar = (number.ToString()).ToCharArray();
           // Array.Reverse(reverseNumberChar);
            //int tempNumber = int.Parse(reverseNumberChar);

            if (tempNumber == number)
            {
                return true;
            }
            else
            {
                return false;
            }




        }
    }
}
