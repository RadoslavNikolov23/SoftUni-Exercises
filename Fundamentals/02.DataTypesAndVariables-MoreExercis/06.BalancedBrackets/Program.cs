using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLines = int.Parse(Console.ReadLine());
            int coutOpen = 0;
            int coutCloes = 0;

            for (int i = 0; i < numberLines; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    coutOpen++;
                }
                else if(input==")" && coutOpen==1)
                {
                    coutOpen = 0;
                    coutCloes++;
                }

                else if (input == ")" && coutOpen == 0)
                {
                    coutOpen = 2;
                }


            }


            if (coutOpen==0 && coutCloes>0)
                Console.WriteLine("BALANCED");
            else
                Console.WriteLine("UNBALANCED");

        }
    }
}
