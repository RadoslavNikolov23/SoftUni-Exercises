using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.TeamworkProjects
{
    class Team
    {
        public string User;
        public string TeamName;
        public List<string> TeamMates;

        public Team(string user, string teamName)
        {
            User = user;
            TeamName = teamName;
            TeamMates = new List<string>();
        }

        //public override string ToString()
        //{
        //    return $"{TeamName}\n" +
        //           $"- {User}\n" +
        //           $"{(string.Join(Environment.NewLine, TeamMates.Select(mates => "-- " + mates)))}";
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> teamList = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] inputArray = Console.ReadLine().Split("-");
                string user = inputArray[0];
                string teamName = inputArray[1];

                Team teamExist = teamList.FirstOrDefault(mate => mate.TeamName == teamName);
                Team userExist = teamList.FirstOrDefault(creator => creator.User == user);
                //if (teamExist == null && userExist == null)
                //{
                //    teamList.Add(new Team(user, teamName));
                //    Console.WriteLine($"Team {teamName} has been created by {user}!");
                //}

                if (teamExist != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (userExist != null)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }

                teamList.Add(new Team(user, teamName));
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] inputArray = input.Split("->");
                string teamMate = inputArray[0];
                string team = inputArray[1];

                //Team foundTeam = teamList.FirstOrDefault(teams => teams.TeamName == team);
                //Team foundMember = teamList.FirstOrDefault(mate => mate.User == teamMate);
                //Team foundMemberInMates = teamList.FirstOrDefault(mate => mate.TeamMates.Contains(teamMate));

                //if (foundTeam != null && foundMember == null)
                //{
                //    int index = teamList.FindIndex(mate => mate.TeamName == team);
                //    teamList[index].TeamMates.Add(teamMate);
                //}

                if (!teamList.Any(t => t.TeamName == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }

                if (teamList.Any(team => team.User == teamMate) ||
                    teamList.Any(team => team.TeamMates.Contains(teamMate)))
                //if (foundMember != null || foundMemberInMates !=null)
                {
                    Console.WriteLine($"Member {teamMate} cannot join team {team}!");
                    continue;
                }

                //int index = teamList.FindIndex(mate => mate.TeamName == team);
                //teamList[index].TeamMates.Add(teamMate);

              teamList.Find(t => t.TeamName == team).TeamMates.Add(teamMate);

            }

            List<Team> orderdTeamList = teamList
                .Where(x => x.TeamMates.Count > 0)
                .OrderByDescending(x => x.TeamMates.Count)
                .ThenBy(x => x.TeamName)
                .ToList();



            foreach (var team in orderdTeamList)
            {

                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.User}");
                for (int i = 0; i < team.TeamMates.Count; i++)
                {
                    Console.WriteLine($"-- {team.TeamMates[i]}");
                }

            }

            List<Team> disbandTeams = teamList.Where(x => x.TeamMates.Count <= 0).ToList();

            TeamsToDisbandPrint(disbandTeams);

        }

        private static void TeamsToDisbandPrint(List<Team> disbandTeams)
        {
            Console.WriteLine("Teams to disband:");

            foreach (var team in disbandTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}

