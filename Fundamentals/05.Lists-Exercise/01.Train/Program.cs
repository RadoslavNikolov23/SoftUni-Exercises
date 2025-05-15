namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //On the first line, we will receive a list of wagons(integers). 
            //    Each integer represents the number of passengers that are currently in each wagon of the passenger train. 
            //    On the next line, you will receive the max capacity of a wagon, represented as a single integer. 
            //    Until you receive the "end" command, you will be receiving two types of input:
            //    •	Add { passengers} – add a wagon to the end of the train with the given number of passengers.
            //    •	{ passengers} – find a single wagon to fit all the incoming passengers(starting from the first wagon).
            //In the end, print the final state of the train(all the wagons separated by a space).

            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity=int.Parse(Console.ReadLine());
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArray = input.Split();

                if (inputArray[0] == "Add")
                {
                    wagons.Add(int.Parse(inputArray[1]));
                }
                else
                {
                    int passangers= int.Parse(inputArray[0]);
                    for (int i = 0; i < wagons.Capacity; i++)
                    {
                        if (wagons[i] + passangers <= maxCapacity)
                        {
                            wagons[i] += passangers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",wagons));



        }
    }
}
