using System;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cardsFirstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> cardsSecondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool gameOver = false;


            while (!gameOver)
            {
                //The player, who holds the more powerful card on the current iteration,
                //    takes both cards and puts them at the back of his hand 
                //    - the second player's card is placed last and the first person's card(the winning one) 
                //comes after it(second to last).
                if (cardsFirstPlayer[0] > cardsSecondPlayer[0])
                {
                    cardsFirstPlayer.Add(cardsSecondPlayer[0]);
                    cardsFirstPlayer.Add(cardsFirstPlayer[0]);
                    cardsSecondPlayer.RemoveAt(0);
                    cardsFirstPlayer.RemoveAt(0);

                }
                else if (cardsFirstPlayer[0] < cardsSecondPlayer[0])
                {
                    cardsSecondPlayer.Add(cardsFirstPlayer[0]);
                    cardsSecondPlayer.Add(cardsSecondPlayer[0]);
                    cardsFirstPlayer.RemoveAt(0);
                    cardsSecondPlayer.RemoveAt(0);

                }
                else if (cardsFirstPlayer[0] == cardsSecondPlayer[0])
                {
                    cardsFirstPlayer.RemoveAt(0);
                    cardsSecondPlayer.RemoveAt(0);
                }

                if (cardsFirstPlayer.Count == 0)
                {
                    gameOver = true;
                }
                if (cardsSecondPlayer.Count == 0)
                {
                    gameOver = true;
                }
            }

            int sumWinDeck = 0;
            if (cardsFirstPlayer.Count > 0)
            {
                for (int i = 0; i < cardsFirstPlayer.Count; i++)
                {
                    sumWinDeck += cardsFirstPlayer[i];
                }

                Console.WriteLine($"First player wins! Sum: {sumWinDeck}");
            
            }
            else if (cardsSecondPlayer.Count > 0)
            {
                for (int i = 0; i < cardsSecondPlayer.Count; i++)
                {
                    sumWinDeck += cardsSecondPlayer[i];
                }

                Console.WriteLine($"Second player wins! Sum: {sumWinDeck}");
            }
        }
    }
}
