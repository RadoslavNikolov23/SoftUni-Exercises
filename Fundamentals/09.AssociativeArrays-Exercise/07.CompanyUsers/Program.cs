using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyDictioner = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] array = input.Split(" -> ");
                string compName = array[0];
                string userId = array[1];

                if (!companyDictioner.ContainsKey(compName))
                {
                    companyDictioner.Add(compName, new List<string>() { userId });
                }
                else
                {
                    if (!companyDictioner[compName].Contains(userId))
                    {
                        companyDictioner[compName].Add(userId);
                    }
                }
            }

            foreach (var item in companyDictioner)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
        

            }

        }
    }
}
