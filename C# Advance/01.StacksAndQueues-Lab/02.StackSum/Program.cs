using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrayNumbers = Console.ReadLine()
                        .Split(" ")
                        .Select(int.Parse)
                        .ToArray();

            Stack<int> stackNumber = new Stack<int>(arrayNumbers);

            string command;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandArray = command.Split();

                switch (commandArray[0])
                {
                    case "add":
                        stackNumber.Push(int.Parse(commandArray[1]));
                        stackNumber.Push(int.Parse(commandArray[2]));
                        break;

                    case "remove":
                        int numberOfRemoves = int.Parse(commandArray[1]);
                        if (numberOfRemoves <= stackNumber.Count)
                        {
                            for (int i = 0; i < numberOfRemoves; i++)
                            {
                                stackNumber.Pop();
                            }
                        }
                        break;
                    
                }
            }
            Console.WriteLine($"Sum: {stackNumber.Sum()}");
        }
    }
}
