namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPass = int.Parse(Console.ReadLine());
            Queue<string> queueCars= new Queue<string>();
            int counterCarsThatPass = 0;

            if (string command;)

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    int tempPassCounter = numberOfCarsToPass;
                    while (tempPassCounter > 0 && queueCars.Count > 0)
                    {
                        Console.WriteLine($"{queueCars.Dequeue()} passed!");
                        tempPassCounter--;
                        counterCarsThatPass++;
                    }
                }
                else
                {
                    queueCars.Enqueue(command);
                }

            }

            Console.WriteLine($"{counterCarsThatPass} cars passed the crossroads.");

        }
    }
}
