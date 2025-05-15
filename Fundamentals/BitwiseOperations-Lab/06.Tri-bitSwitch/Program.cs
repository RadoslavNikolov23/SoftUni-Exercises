using System;

namespace _06.Tri_bitSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int possition = int.Parse(Console.ReadLine());


            for (int i = 0; i < 3; i++)
            {
                int bit = (number >> i + possition) & 1;

                int mask = (int)1 << i + possition;

                if (bit == 1)
                {
                    number = number & ~(mask);
                }
                else
                {
                    number = number | mask;
                }
            }

            Console.WriteLine(number);
        }
    }
}
