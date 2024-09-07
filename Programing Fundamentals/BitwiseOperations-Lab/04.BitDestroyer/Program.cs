using System;

namespace _04.BitDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int atPossition = int.Parse(Console.ReadLine());

            int mask = (int)1 << atPossition;
            int newNumber = number & ~(mask);

            Console.WriteLine(newNumber);
        }
    }
}
