using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {

            string input= Console.ReadLine();

            string cipherCaeserCode = CipherTheString(input);
            Console.WriteLine(cipherCaeserCode);

        }

        public static string CipherTheString(string input)
        {
            string cipherString = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char tempChar = (char)(input[i] + 3);
                cipherString += tempChar;

            }

            return cipherString;
        }
    }
}
