using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());
            string thirdSt = Console.ReadLine();
            int sumCh = 0;

            for (int i = 0; i < thirdSt.Length; i++)
            {
                int tempChar = thirdSt[i];
                if (tempChar>(int)firstCh && tempChar<(int)secondCh)
                {
                    sumCh += tempChar;
                }

            }
            Console.WriteLine(sumCh);

        }
    }
}
