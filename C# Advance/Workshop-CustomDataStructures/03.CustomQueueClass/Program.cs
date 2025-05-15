using System;

namespace _03.CustomQueueClass
{
    public class Program
    {
        static void Main(string[] args)
        {

            CustomsQueue queueCustom = new CustomsQueue();

            for(int i = 0; i < 5; i++)
            {
                queueCustom.Enqueue(i + 100);
            }

            queueCustom.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            Console.WriteLine(queueCustom.Peek());
            Console.WriteLine();


            Console.WriteLine(queueCustom.Dequeue());

            Console.WriteLine();

            Console.WriteLine(queueCustom.Count);
            Console.WriteLine();

            queueCustom.Clear();

            Console.WriteLine(queueCustom.Count);
        }
    }
}
