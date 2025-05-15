using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] twoStrings = Console.ReadLine().Split();

            int sumAllCharakters = MultiplyAllChar(twoStrings[0], twoStrings[1]);
          
            Console.WriteLine(sumAllCharakters);
        }

        public static int MultiplyAllChar(string stringOne, string stringTwo)
        {
            
            int sumChar=0;
          

            if (stringOne.Length > stringTwo.Length)
            {
                for (int i = 0; i < stringTwo.Length; i++)
                {
                    sumChar += (stringOne[i] * stringTwo[i]);
                }

                for (int i = stringOne.Length-1; i > stringTwo.Length-1; i--)
                {
                    sumChar += stringOne[i];
                }
            }
            else
            {
                for (int i = 0; i < stringOne.Length; i++)
                {
                    sumChar += (stringOne[i] * stringTwo[i]);
                }

                for (int i = stringTwo.Length - 1; i > stringOne.Length-1; i--)
                {
                    sumChar += stringTwo[i];
                }
            }

            return sumChar;
        }
    }
}
