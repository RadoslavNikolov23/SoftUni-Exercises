using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] data = input.Split(";");

                    if (data[0] == "Team") teams.Add(new Team(data[1]));

                    else if (data[0] == "Add")
                    {
                        string teamName = data[1];
                        string playerName = data[2];
                        int endurance = int.Parse(data[3]), spring = int.Parse(data[4]), dribble = int.Parse(data[5]),
                            passing = int.Parse(data[6]), shooting = int.Parse(data[7]);

                        if (ValidateTeam(teamName, teams))
                        {
                            int index = teams.FindIndex(x => x.NameTeam == teamName);

                            teams[index].AddPlayer(new Player(playerName, endurance, spring, dribble, passing, shooting), teamName);

                        }
                        else Console.WriteLine($"Team {teamName} does not exist.");

                    }
                    else if (data[0] == "Remove")
                    {
                        string teamName = data[1];
                        string playerName = data[2];

                        if (ValidateTeam(teamName, teams))
                        {
                            int index = teams.FindIndex(x => x.NameTeam == teamName);
                            teams[index].RemovePlayer(playerName);
                        }
                        else Console.WriteLine($"Team {teamName} does not exist.");
                  
                    }


                    else if (data[0] == "Rating")
                    {
                        string teamName = data[1];
                        if (ValidateTeam(teamName, teams)) Console.WriteLine(teams.First(x => x.NameTeam == teamName));
                        else Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine();
            }

        }

        private static bool ValidateTeam(string teamName, List<Team> teams) => teams.Any(x => x.NameTeam == teamName);


    }
}
