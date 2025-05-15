using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, string, string, bool> filterPRFM = ReturnFunc;

            bool ReturnFunc(string guest, string filterType, string filterParameter)
            {
                if (filterType == "Starts with")
                {
                    return !guest.StartsWith(filterParameter);
                }
                else if (filterType == "Ends with")
                {
                    return !guest.EndsWith(filterParameter);
                }
                else if (filterType == "Length")
                {
                    return guest.Length != int.Parse(filterParameter);
                }
                else
                {
                    return !guest.Contains(filterParameter);
                }
            }

            List<string> listOfPeaple = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, List<string>> filtersPRFM = new Dictionary<string, List<string>>();

            string commands = Console.ReadLine();

            while (commands != "Print")
            {
                string[] array = commands.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string commandPRFM = array[0], filterType = array[1], filterParameter = array[2];


                //if (!filtersPRFM.ContainsKey(commandPRFM))
                //{
                //    filtersPRFM.Add(commandPRFM, new List<string>());
                //}

                //filtersPRFM[commandPRFM].Add($"{filterType};{filterParameter}");

                if (commandPRFM == "Add filter")
                {
                    if (!filtersPRFM.ContainsKey(commandPRFM))
                    {
                        filtersPRFM.Add(commandPRFM, new List<string>());
                    }

                    filtersPRFM[commandPRFM].Add($"{filterType};{filterParameter}");
                }
                else if (commandPRFM == "Remove filter")
                {
                    filtersPRFM["Add filter"].Remove($"{filterType};{filterParameter}");
                }


                commands = Console.ReadLine();
            }



            foreach (var (command, fillters) in filtersPRFM)
            {
                foreach (var fillter in fillters)
                {
                    string filterType = fillter.Split(';').First();
                    string filterParameter = fillter.Split(';').Last();
                    listOfPeaple = listOfPeaple.Where(x => filterPRFM(x, filterType, filterParameter)).ToList();
                }
            }


            Console.WriteLine(string.Join(" ", listOfPeaple));
        }

    }
}
