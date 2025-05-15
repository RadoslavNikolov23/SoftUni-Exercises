
namespace _03._MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerPool = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "Season end")
            {
                if (input.Contains("vs"))
                {
                    string[] arrayVS = input.Split("vs", StringSplitOptions.TrimEntries);
                    string playerOne = arrayVS[0];
                    string playerTwo = arrayVS[1];

                    if (playerPool.ContainsKey(playerOne) && playerPool.ContainsKey(playerTwo))
                    {
                        foreach (var position in playerPool[playerOne].Keys)
                        {
                            if (playerPool[playerTwo].ContainsKey(position))
                            {
                                int playerOneSkills = playerPool[playerOne].Values.Sum();
                                int playerTwoSkills = playerPool[playerTwo].Values.Sum();

                                if (playerOneSkills > playerTwoSkills)
                                {
                                    playerPool.Remove(playerTwo);
                                } 
                                else if (playerOneSkills < playerTwoSkills)
                                {
                                    playerPool.Remove(playerOne);
                                }
                                break;
                            }
                        }
                       
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    string[] arrayADD = input.Split("->", StringSplitOptions.TrimEntries);
                    string playerName = arrayADD[0];
                    string playerPosition = arrayADD[1];
                    int playerSkill = int.Parse(arrayADD[2]);

                    if (!playerPool.ContainsKey(playerName))
                    {
                        playerPool.Add(playerName, new Dictionary<string, int>());
                    }

                    if (!playerPool[playerName].ContainsKey(playerPosition))
                    {
                        playerPool[playerName].Add(playerPosition, playerSkill);
                    }

                    if (playerPool[playerName][playerPosition] < playerSkill)
                    {
                        playerPool[playerName][playerPosition] = playerSkill;
                    }
                }
            }


            foreach (var player in playerPool.OrderByDescending(pl=>pl.Value.Values.Sum())
                                             .ThenBy(pl=>pl.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var posAndSkill in player.Value.OrderByDescending(pl=>pl.Value)
                                                        .ThenBy(pl=>pl.Key))
                {
                    Console.WriteLine($"- {posAndSkill.Key} <::> {posAndSkill.Value}");
                }
            }
        }
    }
}
