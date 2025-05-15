using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int[] arrayPassword = new int[3];

//            for (int i = 0; i < password.Length; i++)
//            {
//              //  string temp = password[i].ToString;
/////arrayPassword[i] = int.Parse(temp);
//            }

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if(i==arrayPassword[0] && k == arrayPassword[1] && j == arrayPassword[2])
                        {
                            Console.WriteLine("Password found");
                            Console.WriteLine($"{i}, {k}, {j}");
                        }

                    }
                }

            }



        }
    }
}
