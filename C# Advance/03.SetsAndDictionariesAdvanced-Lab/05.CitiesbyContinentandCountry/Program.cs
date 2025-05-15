namespace _05.CitiesbyContinentandCountry
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentMaps = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] array = Console.ReadLine().Split(" ");

                string continent = string.Empty;
                string country = string.Empty;
                string city = string.Empty;

                if (args.Length == 3)
                {

                    continent = array[0];
                    country = array[1];
                    city = array[2];
                }
                else
                {
                    continent = array[0];
                    country = array[1];
                    for (int j = 2; j < array.Length; j++)
                    {
                        if (j > 2) city += " ";
                        city += array[j];
                    }
                }

                if (!continentMaps.ContainsKey(continent))
                {
                    continentMaps.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continentMaps[continent].ContainsKey(country))
                {
                    continentMaps[continent].Add(country, new List<string>());

                }

                    continentMaps[continent][country].Add(city);
               
            }

            foreach (var continent in continentMaps)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {(string.Join(", ", country.Value))}");
                }
            }

        }
    }
}
