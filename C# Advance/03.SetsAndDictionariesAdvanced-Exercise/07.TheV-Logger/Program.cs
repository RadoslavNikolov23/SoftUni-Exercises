using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Vlog
    {
        public Vlog(HashSet<string> followers, int coutManyFollowing)
        {
            Followers = followers;
            CoutManyFollowing = coutManyFollowing;
        }

        public HashSet<string> Followers { get; set; }
        public int CoutManyFollowing { get; set; }
    }
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Vlog> vloggersAndFollowers = new Dictionary<string, Vlog>();

            while (input != "Statistics")
            {
                string[] array = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = array[1];

                switch (command)
                {
                    case "joined":
                        string joinedVloger = array[0];
                        if (!vloggersAndFollowers.ContainsKey(joinedVloger))
                        {
                            vloggersAndFollowers.Add(joinedVloger, new Vlog(new HashSet<string>(), 0));
                        }

                        break;

                    case "followed":
                        string follower = array[0];
                        string vlogger = array[2];

                        if (vloggersAndFollowers.ContainsKey(vlogger) &&
                            vloggersAndFollowers.ContainsKey(follower) &&
                            follower != vlogger &&
                            vloggersAndFollowers[vlogger].Followers.Add(follower))
                        {
                            vloggersAndFollowers[follower].CoutManyFollowing++;
                        }

                        break;
                }

                input = Console.ReadLine();

            }
            PrintOutput(vloggersAndFollowers);
        }

        private static void PrintOutput(Dictionary<string, Vlog> vloggersAndFollowers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggersAndFollowers.Keys.Count} vloggers in its logs.");

            int count = 1;
            foreach (var (vlogger, following) in vloggersAndFollowers.OrderByDescending(x => x.Value.Followers.Count())
                .ThenBy(x => x.Value.CoutManyFollowing))
            {
                Console.WriteLine($"{count}. {vlogger} : {following.Followers.Count()} followers, {following.CoutManyFollowing} following");
                if (count == 1)
                {
                    foreach (var follower in following.Followers.OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
