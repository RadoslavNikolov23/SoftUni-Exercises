using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        public class Contest
        {
            private string name;
            private string password;

            public Contest(string name, string password)
            {
                Name = name;
                Password = password;
            }

            public string Name { get => name; set => name = value; }
            public string Password { get => password; set => password = value; }
        }
        static void Main(string[] args)
        {

            List<Contest> contestList = new List<Contest>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] array = input.Split(":");
                string nameContest = array[0], passwordContest = array[1];
                contestList.Add(new Contest(nameContest, passwordContest));

                input = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> rankingDT = new Dictionary<string, Dictionary<string, int>>();
            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] array = input.Split("=>");
                string nameContest = array[0], passwordContest = array[1], username = array[2];
                int points = int.Parse(array[3]);

                Contest tempContes = new Contest(nameContest, passwordContest);
                if (contestList.Any(x => x.Name == nameContest && x.Password == passwordContest))
                {
                    if (!rankingDT.ContainsKey(username))
                    {
                        rankingDT.Add(username, new Dictionary<string, int>());

                    }

                    if (rankingDT[username].Any(x => x.Key == nameContest))
                    {
                        if (rankingDT[username][nameContest] < points)
                        {
                            rankingDT[username][nameContest] = points;
                        }
                    }
                    else
                    {
                        rankingDT[username].Add(nameContest, points);
                    }
                }

                input = Console.ReadLine();
            }

            PrintOutput(rankingDT);

        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> rankingDT)
        {
            var maxUser = rankingDT.OrderByDescending(x => x.Value.Sum(i => i.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {maxUser.Key} with total {maxUser.Value.Sum(x => x.Value)} points.");

            Console.WriteLine("Ranking:");
            foreach (var (user, contests) in rankingDT.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user}");
                foreach (var (contest, points) in contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
