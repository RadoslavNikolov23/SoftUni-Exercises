using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> morseAlphabet = new Dictionary<string, string>()
            {
            { "A", ".-" }, { "B", "-..." }, { "C", "-.-." }, { "D", "-.." }, { "E", "." },
            { "F", "..-." }, { "G", "--." }, { "H", "...." }, { "I", ".." }, { "J", ".---" },
            { "K", "-.-" }, { "L", ".-.." }, { "M", "--" }, { "N", "-." }, { "O", "---" },
            { "P", ".--." }, { "Q", "--.-" }, { "R", ".-." }, { "S", "..." }, { "T", "-" },
            { "U", "..-" }, { "V", "...-" }, { "W", ".--" }, { "X", "-..-" }, { "Y", "-.--" },
            { "Z", "--.."}, {" ", "|"}
             };

            string[] input = Console.ReadLine().Split();
            string message = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var morse in morseAlphabet)
                {
                    if (morse.Value == input[i])
                    {
                        message += morse.Key;
                    }

                }
            }

            Console.WriteLine(message);

        }
    }
}
