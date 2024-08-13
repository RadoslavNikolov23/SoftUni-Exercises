using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.AMinerTask
{

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> minerDictionary = new Dictionary<string, int>();

            string command;
            int counter = 0;
            while ((command = Console.ReadLine()) != "stop")
            {
                counter++;
                string resourse;
                int quantity;

                if (counter % 2 == 1)
                {
                    resourse = command;

                    command = Console.ReadLine();
                    counter++;

                    if (counter % 2 == 0)
                    {
                        quantity = int.Parse(command);
                        if (!minerDictionary.ContainsKey(resourse))
                        {
                            minerDictionary.Add(resourse, quantity);
                        }
                        else
                        {
                            minerDictionary[resourse] += quantity;
                        }
                    }

                }
           


            }
            foreach (var pair in minerDictionary)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
