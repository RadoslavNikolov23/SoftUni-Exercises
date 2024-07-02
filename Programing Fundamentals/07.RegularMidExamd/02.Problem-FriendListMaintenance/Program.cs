using System.Collections.Generic;
using System.Xml.Linq;

namespace _02.Problem_FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine().Split(", ").ToList();
            string input;

            int countBlacklist = 0;
            int countLost = 0;

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] inputArray = input.Split();

                switch (inputArray[0])
                {
                    case "Blacklist":
                        string nameBlacklist = inputArray[1];
                        friendsList = BlackList(friendsList, nameBlacklist);
                        break;

                    case "Error":
                        int indexError = int.Parse(inputArray[1]);
                        friendsList = Errorlist(friendsList, indexError);
                        break;
                    case "Change":
                        int indexChange = int.Parse(inputArray[1]);
                        string nameChange = inputArray[2];
                        friendsList = Changelist(friendsList, indexChange, nameChange);
                        break;

                }

            }

            foreach (var name in friendsList)
            {
                if (name == "Blacklisted")
                {
                    countBlacklist++;
                }

                if (name == "Lost")
                {
                    countLost++;
                }
            }

            if (input == "Report")
            {
                Console.WriteLine($"Blacklisted names: {countBlacklist}");
                Console.WriteLine($"Lost names: {countLost}");
                Console.WriteLine(string.Join(" ", friendsList));


            }


        }

        private static List<string> Changelist(List<string> friendsList, int indexChange, string nameChange)
        {
            if (isValidIndex(friendsList, indexChange))
            {
                string tempName = friendsList[indexChange];
                friendsList[indexChange] = nameChange;
                Console.WriteLine($"{tempName} changed his username to {nameChange}.");

            }
            //•	"Change {index} {new name}":  
            //•	If the index is valid, change the current username with the new one
            //and print "{current name} changed his username to {new name}.".
            //    •	Otherwise, ignore the command.
            return friendsList;

        }

        static List<string> Errorlist(List<string> friendsList, int indexError)
        {
            //•	"Error {index}":

            if (isValidIndex(friendsList, indexError))
            {
                if (friendsList[indexError] != "Blacklisted" && friendsList[indexError] != "Lost")
                {
                    string tempName = friendsList[indexError];
                    friendsList[indexError] = "Lost";
                    Console.WriteLine($"{tempName} was lost due to an error.");
                    return friendsList;
                }
            }
            //•	If the index is valid and the username at the given index 
            //    is not blacklisted or already lost due to an error, change it to "Lost"
            // and print "{name} was lost due to an error.".
            //    •	Otherwise, ignore the command.

            return friendsList;
        }

        static List<string> BlackList(List<string> friendsList, string nameBlacklist)
        {
            //•	"Blacklist {name}":
            //•	Change the given name to "Blacklisted" and print "{name} was blacklisted.".
            // •	If there is no such name print: "{name} was not found."
            if (friendsList.Contains(nameBlacklist))
            {
                for (int i = 0; i < friendsList.Count; i++)
                {
                    if (friendsList[i] == nameBlacklist)
                    {
                        string tempname = friendsList[i];
                        friendsList[i] = "Blacklisted";
                        Console.WriteLine($"{tempname} was blacklisted.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{nameBlacklist} was not found.");
            }

            return friendsList;
        }

        static bool isValidIndex(List<string> friendsList, int indexError)
        {
            if (indexError >= 0 && indexError < friendsList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
            //An index is valid when it is non - negative and less than the size of the collection.

        }
    }
}
