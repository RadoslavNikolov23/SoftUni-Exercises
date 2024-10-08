using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CustomStackClass
{
    public class Program
    {
        static void Main()
        {
            CustomStack customStack = new CustomStack();

            for(int i = 0; i < 5; i++)
            {
                customStack.Push(i);
            }

            Console.WriteLine(customStack.Peek());
            Console.WriteLine();
            customStack.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            while (customStack.Count != 0)
            {
                Console.WriteLine(customStack.Pop());
            }

            Console.WriteLine();
            Console.WriteLine(customStack.Count);

        }
    }
}
