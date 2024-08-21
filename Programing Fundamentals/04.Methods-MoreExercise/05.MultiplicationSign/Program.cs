using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            ChechIfResultIsPosOrNeg2(a, b, c);
        }

        private static void ChechIfResultIsPosOrNeg2(int a, int b, int c)
        {
            //So, the result is negative if you have 1 or 3 (an odd number) negative numbers.
            //    If you have 0 or 2 (an even number) negative numbers, the result will be positive.

            int[] array = new int[3] { a,b,c};
            int countPositive = 0;
            for (int i = 0; i < 3; i++)
            {
                if (array[i] >= 0)
                {
                    countPositive++;
                }
            }

            if(a==0 || b==0 || c == 0)
            {
                Console.WriteLine("zero");
            }
            else if (countPositive % 2 == 0)
            {
                Console.WriteLine("negative");

            }
            else
            {
                Console.WriteLine("positive");

            }
        }

       

      
    }
}
