using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();


            Dictionary<string, List<string>> forceDT = new Dictionary<string, List<string>>();
            while (input != "Lumpawaroo")
            {

                if (input.Contains('|'))
                {
                    string[] data = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = data[0];
                    string forceUser = data[1];

                    if (!forceDT.ContainsKey(forceSide))
                    {
                        forceDT.Add(forceSide, new List<string>());
                    }

                    if (!forceDT.Any(x => x.Value.Contains(forceUser)))
                    {
                        forceDT[forceSide].Add(forceUser);
                    }


                }
                else
                {
                    string[] data = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = data[0];
                    string forceSide = data[1];


                    if (!forceDT.ContainsKey(forceSide))
                    {
                        forceDT.Add(forceSide, new List<string>());

                    }

                    if (forceDT.Any(x => x.Value.Any(i => i == forceUser)))
                    {
                        var origSide = GetKey(forceDT, forceUser);

                        forceDT[origSide].Remove(forceUser);
                        forceDT[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                    }
                    else
                    {
                        forceDT[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                }

                input = Console.ReadLine();
            }

            foreach (var forceSide in forceDT.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (forceSide.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {forceSide.Key}, Members: {forceSide.Value.Count}");

                    Console.WriteLine($"! {string.Join("\n! ", forceSide.Value.OrderBy(x => x))}");
                }


            }

        }



        public static string GetKey(Dictionary<string, List<string>> dictionary, string forseUser)
        {
            foreach (var keyValue in dictionary)
            {
                foreach (var value in keyValue.Value)
                {
                    if (value == forseUser)
                    {
                        return keyValue.Key;
                    }
                }

            }
            return null;
        }
    }
}
