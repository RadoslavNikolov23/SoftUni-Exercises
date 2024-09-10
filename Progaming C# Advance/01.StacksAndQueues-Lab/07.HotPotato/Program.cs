namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kidNames = Console.ReadLine().Split(" ");
            int numberOfTosses = int.Parse(Console.ReadLine());

            Queue<string> queueKids= new Queue<string>(kidNames);

            while (queueKids.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    queueKids.Enqueue(queueKids.Dequeue());
                }

                Console.WriteLine($"Removed {queueKids.Dequeue()}");
            }

            Console.WriteLine($"Last is {queueKids.Peek()}");
            
        }
    }
}
