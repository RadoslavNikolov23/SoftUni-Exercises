

namespace _01.Ranking
{
    internal class Program
    {
        class ContestUser
        {
            public ContestUser(string contestName, int contestPoints)
            {
                ContestName = contestName;
                ContestPoints = contestPoints;
            }

            public string ContestName { get; set; }
            public int ContestPoints { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> contansDictionary = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] array = input.Split(":");
                string nameContest = array[0];
                string passwordContest = array[1];

                contansDictionary.Add(nameContest, passwordContest);
            }

            Dictionary<string, List<ContestUser>> finalDictionary = new Dictionary<string, List<ContestUser>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] array = input.Split("=>");
                string nameContest = array[0];
                string passwordContest = array[1];
                string userName = array[2];
                int pointsForUser = int.Parse(array[3]);


                if (contansDictionary.ContainsKey(nameContest) && contansDictionary[nameContest] == passwordContest)
                {
                    if (finalDictionary.Any(x=>x.Key==userName))
                    {
                        if (finalDictionary[userName].Any(con => con.ContestName.Contains(nameContest)))
                        {
                            foreach (var us in finalDictionary[userName].FindAll(x=>x.ContestName==nameContest))
                            {
                                if (us.ContestPoints < pointsForUser)
                                {
                                    us.ContestPoints= pointsForUser;
                                }
                            }
                          
                        }
                        else
                        {
                            finalDictionary[userName].Add(new ContestUser(nameContest, pointsForUser));
                        }
                    }
                    else
                    {

                        finalDictionary.Add(userName, new List<ContestUser>
                                                            {
                                                                new ContestUser(nameContest,pointsForUser)

                                                            });
                    }




                }
            }

            string bestUser = string.Empty;
            int pointsBestUser = int.MinValue;

            foreach (var contest in finalDictionary)
            {
                int sumContest = contest.Value.Sum(con => con.ContestPoints);

                if (sumContest > pointsBestUser)
                {
                    pointsBestUser = sumContest;
                    bestUser = contest.Key;
                }

            }





            Console.WriteLine($"Best candidate is {bestUser} with total {pointsBestUser} points.");

            Console.WriteLine("Ranking: ");

            foreach (var contest in finalDictionary.OrderBy(x => x.Key))
            {

                Console.WriteLine($"{contest.Key}");
                foreach (var single in contest.Value.OrderByDescending(x => x.ContestPoints))
                {

                    Console.WriteLine($"#  {single.ContestName} -> {single.ContestPoints}");
                }
            }

        }
    }

}
