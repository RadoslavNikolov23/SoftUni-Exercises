namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> queueCups = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> stackBottles = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int wasteWater = 0;

            while (true)
            {
                int bottle=stackBottles.Pop();
                int cup=queueCups.Peek();

                int result = cup - bottle;
                if (result <= 0)
                {
                    queueCups.Dequeue();
                    wasteWater += Math.Abs(result);
                    //stackBottles.Pop();
                }
                else
                {
                    queueCups.Enqueue(queueCups.Dequeue() - bottle);
                    for (int i = 0; i < queueCups.Count-1; i++)
                    {
                        queueCups.Enqueue(queueCups.Dequeue());
                    }

                }

                if (queueCups.Count == 0 || stackBottles.Count == 0) break;
            }
            if (queueCups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",stackBottles)}");
            }
            else if (stackBottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueCups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wasteWater}");
              
        }
    }
}
