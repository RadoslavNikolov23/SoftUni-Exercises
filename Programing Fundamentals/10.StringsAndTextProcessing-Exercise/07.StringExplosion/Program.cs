using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string finalInput = StringExplosionBomb(input);

            Console.WriteLine(finalInput);
        }

        public static string StringExplosionBomb(string input)
        {
            int bomb = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    bomb += input[i + 1] - '0';
                    continue;
                }

                if (bomb > 0)
                {
                    input = input.Remove(i, 1);
                    bomb--;
                    i--;
                }

            }

            return input;
        }
    }
}
