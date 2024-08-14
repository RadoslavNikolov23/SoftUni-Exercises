using System;

namespace _05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberChar = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < numberChar; i++)
            {
                char tempChar = char.Parse(Console.ReadLine());
                char newChar = (char)(tempChar + key);

                message += newChar;
            }
            Console.WriteLine(message);
            

        }
    }
}
