using System;
using System.Numerics;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfElements = int.Parse(Console.ReadLine());

            BigInteger firstNumber = 1;
            BigInteger SecondNumber = 1;
            BigInteger ThirdNumber = 2;
            BigInteger nextNumber;

            if (numberOfElements <= 0)
            {
                Console.WriteLine();
            }
            else if (numberOfElements <= 1)
            {
                Console.Write(firstNumber);
            }
            else if (numberOfElements <= 2)
            {
                Console.Write(firstNumber + " " + SecondNumber);
            }
            else
            {
                Console.Write(firstNumber + " " + SecondNumber + " " + ThirdNumber + " ");
                for (int i = 3; i < numberOfElements; i++)
                {
                    nextNumber = firstNumber + SecondNumber + ThirdNumber;
                    Console.Write(nextNumber + " ");
                    firstNumber = SecondNumber;
                    SecondNumber = ThirdNumber;
                    ThirdNumber = nextNumber;
                }
            }





        }




    }
}

