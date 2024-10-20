namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            int desureSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> coinsDT = ChooseCoins(coins, desureSum);

            
            Console.WriteLine($"Number of coins to take: {coinsDT.Sum(x=>x.Value)}");
            foreach( (int coinValue, int coinNUmber) in coinsDT)
            {
                Console.WriteLine($"{coinNUmber} coin(s) with value {coinValue}");
            }

        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> coinsDT = new Dictionary<int, int>();

            int currentSum = 0;
            int[] array=coins.OrderByDescending(x => x).ToArray();


            while (true)
            {
                bool error = false;
                if (currentSum >= targetSum) break;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] + currentSum <= targetSum)
                    {
                        if (!coinsDT.ContainsKey(array[i])) coinsDT.Add(array[i], 1);
                        else coinsDT[array[i]]++;
                        currentSum+=array[i];
                        error = true;
                        break;
                    }
                    //else error = true;
                }

               if (!error) throw new InvalidOperationException("Error");

            }
            return coinsDT;
        }
    }
}