using System;
using System.Linq;
using System.Collections.Generic;


namespace _04.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberComands = int.Parse(Console.ReadLine());
            Dictionary<string, string> softUniParkDict = new Dictionary<string, string>();

            for (int i = 0; i < numberComands; i++)
            {
                string[] array = Console.ReadLine().Split();
                string command = array[0];
                string user = array[1];

                switch (command)
                {
                    case "register":
                        string licensePlate = array[2];
                        if (!softUniParkDict.ContainsKey(user))
                        {
                            softUniParkDict.Add(user, licensePlate);
                            Console.WriteLine($"{user} registered {licensePlate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        }
                        break;

                    case "unregister":
                        if (softUniParkDict.ContainsKey(user))
                        {
                            softUniParkDict.Remove(user);
                            Console.WriteLine($"{user} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        break;
                }

            }

            foreach (var pair in softUniParkDict)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
