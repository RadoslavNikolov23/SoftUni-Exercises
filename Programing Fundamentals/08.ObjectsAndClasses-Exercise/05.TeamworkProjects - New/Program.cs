using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.TeamworkProjects___New
{
    class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }

        public List<string> TeamMates;

        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            TeamMates = new List<string>();
        }

        public override string ToString()
        {
            return $"{TeamName}\n" +
                   $"- {Creator}\n" +
                   $"{GetMembersString()}";
        }

        private object GetMembersString()
        {
            TeamMates = TeamMates
                           .OrderBy(name => name)
                           .ToList();

            string result = "";
            for (int i = 0; i < TeamMates.Count - 1; i++)
            {
                result += $"-- {TeamMates[i]}\n";
            }

            result += $"-- {TeamMates[TeamMates.Count - 1]}";
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teamList = new List<Team>();

            int numberTeam = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberTeam; i++)
            {
                string[] inputArray = Console.ReadLine().Split("-");
                string creator = inputArray[0];
                string teamName = inputArray[1];

                Team team = new Team(creator, teamName);
                Team teamExist = teamList.Find(team => team.TeamName == teamName);
                Team creatorExist = teamList.Find(cr => cr.Creator == creator);

                 if (teamExist != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                 if (creatorExist != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                teamList.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] inputArray = input.Split("->");
                string teamMate = inputArray[0];
                string teamToJoin = inputArray[1];


                if (!teamList.Any(t => t.TeamName == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }
                else if (teamList.Any(t => t.TeamMates.Contains(teamMate))
                    || teamList.Any(t => t.Creator == teamMate))
                {
                    Console.WriteLine($"Member {teamMate} cannot join team {teamToJoin}!");
                    continue;
                }

                teamList.Find(team => team.TeamName == teamToJoin).TeamMates.Add(teamMate);
            }

            List<Team> teamsWithMembers = teamList.Where(t => t.TeamMates.Count > 0).ToList();
            List<Team> teamsToDisbland = teamList.Where(t => t.TeamMates.Count <= 0).ToList();

            List<Team> orderTeamsWithMembers = teamsWithMembers.OrderByDescending(tm => tm.TeamMates.Count)
                .ThenBy(tname => tname.TeamName)
                .ToList();


            orderTeamsWithMembers.ForEach(team => Console.WriteLine(team));


            Console.WriteLine("Teams to disband:");
            List<Team> orderTeamsToDisband = teamsToDisbland.OrderBy(t => t.TeamName).ToList();
            orderTeamsToDisband.ForEach(team => Console.WriteLine(team.TeamName));


        }
    }
}
