using System.Threading.Channels;

namespace _01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            CheckNumber(number);
            void CheckNumber(int n)
            {
                if (n > 0)
                {
                    Console.WriteLine($"The number {n} is positive.");

                }
                else if (n == 0)
                {
                    Console.WriteLine($"The number {n} is zero.");

                }
                else
                {
                    Console.WriteLine($"The number {n} is negative.");
                }





            }


    }
    }
}
