using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string,bool> coutUpper = x=>char.IsUpper(x[0]);

            foreach (string word in text.Where(coutUpper))
            {
                Console.WriteLine(word);
            }

        }

        
    }
}
