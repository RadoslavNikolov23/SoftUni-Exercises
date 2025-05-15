using System.Runtime.Serialization;

namespace _02.Judge
{
    internal class Program
    {
        class Contest
        {
            public Contest(string userName, int userPoints)
            {
                UserName = userName;
                UserPoints = userPoints;
            }

            public string UserName { get; set; }
            public int UserPoints { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<Contest>> contestDictionary = new Dictionary<string, List<Contest>>();
            List<Contest> individualDictionary = new List<Contest>();
            string input;

            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] array = input.Split("->", StringSplitOptions.TrimEntries);
                string username = array[0];
                string contestName = array[1];
                int pointsUser = int.Parse(array[2]);




                if (!contestDictionary.ContainsKey(contestName))
                {
                    contestDictionary.Add(contestName, new List<Contest> { new Contest(username, pointsUser) });

                    if (individualDictionary.Any(x => x.UserName == username))
                    {
                        foreach (var contest in individualDictionary)
                        {
                            if (contest.UserName == username)
                            {
                                contest.UserPoints += pointsUser;
                                break;
                            }
                        }
                    }
                    else
                    {
                        individualDictionary.Add(new Contest(username, pointsUser));
                    }
                }

                if (contestDictionary[contestName].Any(x => x.UserName == username))
                {
                    foreach (var user in contestDictionary[contestName])
                    {
                        if (user.UserName == username)
                        {
                            if (user.UserPoints < pointsUser)
                            {
                                user.UserPoints = pointsUser;
                                foreach (var contest in individualDictionary)
                                {
                                    if (contest.UserName == username)
                                    {
                                        contest.UserPoints = pointsUser;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    contestDictionary[contestName].Add(new Contest(username, pointsUser));

                    if (individualDictionary.Any(x => x.UserName == username))
                    {
                        foreach (var contest in individualDictionary)
                        {
                            if (contest.UserName == username)
                            {
                                contest.UserPoints += pointsUser;
                                break;
                            }
                        }
                    }
                    else
                    {
                        individualDictionary.Add(new Contest(username, pointsUser));
                    }
                }

            }

            foreach (var contest in contestDictionary)
            {
                int sumContestest = contest.Value.Count();
                Console.WriteLine($"{contest.Key}: {sumContestest} participants");
                int i = 1;
                foreach (var user in contest.Value.OrderByDescending(x => x.UserPoints).ThenBy(x => x.UserName))
                {
                    Console.WriteLine($"{i++}. {user.UserName} <::> {user.UserPoints}");

                }
            }

            Console.WriteLine("Individual standings:");
            int place = 1;
            foreach (var indivialUser in individualDictionary.OrderByDescending(x => x.UserPoints).ThenBy(x => x.UserName))
            {
                Console.WriteLine($"{place++}. {indivialUser.UserName} -> {indivialUser.UserPoints}");
            }
        }
    }
}
