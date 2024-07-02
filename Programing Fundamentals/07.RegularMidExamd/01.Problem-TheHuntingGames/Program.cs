using Console = System.Console;

namespace _01.Problem_TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int days = int.Parse(Console.ReadLine());
            int countPlayers = int.Parse(Console.ReadLine());
            decimal groupEnergy = decimal.Parse(Console.ReadLine());

            decimal provisionForOnePlayer = 0;
            decimal waterPerPlayer = decimal.Parse(Console.ReadLine());
            decimal foodPerPlayer = decimal.Parse(Console.ReadLine());

            decimal waterAll = waterPerPlayer * countPlayers * days;
            decimal foodAll = foodPerPlayer * countPlayers * days;

          
            for (int i = 1; i <= days; i++)
            {
                decimal lostEnergy = decimal.Parse(Console.ReadLine());

                groupEnergy -= lostEnergy;

              


                if (groupEnergy <= 0)
                {
                    break;
                }
                if (i % 2 == 0)
                {
                    groupEnergy += (groupEnergy * 5 / 100);
                    waterAll -= (waterAll * 30 / 100);
                }

                if (i % 3 == 0)
                {
                    foodAll -= (foodAll / countPlayers);
                    groupEnergy += (groupEnergy * 10 / 100);
                }

            }

            if (groupEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {foodAll:f2} food and {waterAll:f2} water.");

            }



        }
    }
}
