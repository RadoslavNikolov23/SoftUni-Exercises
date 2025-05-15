using System;
using System.Collections.Generic;

namespace Project_RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
          
            
            const string rock = "rock";
            const string paper = "paper";
            const string scissors = "scissors";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Let's play a game Rock, Paper, Scissors.\n");
            int countWins = 0;
            int countLoses = 0;
            int countDraws = 0;

        ChoiseSymbol:                                   /* The part where the palyer choises Rock, Papper or Scissors. 
                                                           It's a loop, that if the input is other than "r", "p" or "s",
                                                           it comes back here and gives the player another try.*/
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Choose [r] for Rock, [p] for Paper or [s] Scissors: ");
            Console.ForegroundColor = ConsoleColor.White;

            string playerChoise = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (playerChoise == "r")
            {
                playerChoise = rock;
            }
            else if (playerChoise == "p")
            {
                playerChoise = paper;
            }
            else if (playerChoise == "s")
            {
                playerChoise = scissors;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again... \n");
                goto ChoiseSymbol;
            }


            Random random = new Random();
            int computerNumber = random.Next(1, 4);
            string computerChoise = string.Empty;

            computerChoise = ComputerChoiseMethod
            (computerNumber, computerChoise, rock, paper, scissors);  //Method that returns the computer choise.

            List<string> listParametersForGame = new List<string>()
            { playerChoise, computerChoise, rock, paper, scissors, 
              countWins.ToString(), countLoses.ToString(), countDraws.ToString() };

            listParametersForGame = PlayGame(listParametersForGame);  /*The game method.
                                                                        It's a List, where you get the outcome, 
                                                                        but returns the counts of wins, loses and draws.*/
            countWins = int.Parse(listParametersForGame[5]);
            countLoses = int.Parse(listParametersForGame[6]);
            countDraws = int.Parse(listParametersForGame[7]);

        ChoisePlayAgain:                                        /*The part where the player choise if he wants to play another game.
                                                                 If chose "yes" the console goes to the game method, if "no" the
                                                                 console goes to the last Output Method.*/
            Console.Write("Would you like to play again: [y] for \"yes\" or [n] for \"no\": ");
            string playAgainChoise = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (playAgainChoise == "yes" || playAgainChoise=="y")
            {
                goto ChoiseSymbol;
            }
            else if (playAgainChoise == "no" || playAgainChoise=="n")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thanks for playing. Goodbye!\n");
                Console.ForegroundColor = ConsoleColor.White;
                DisplayWinsLoses(countWins, countLoses, countDraws);    /*The last Output Method, where you will have 
                                                                         * the avarage procent of the wins, loses and draws.*/
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Try again\n");
                Console.ForegroundColor = ConsoleColor.White;
                goto ChoisePlayAgain;                                   /*This part gives the player another try, if he put
                                                                         a invalid input. Returs him to the part where he choses
                                                                         if he wants to play another game or not.*/
            }

        }


        private static List<string> PlayGame(List<string> listParametersForGame)
        {
            string playerChoise = listParametersForGame[0];
            string computerChoise = listParametersForGame[1];
            string rock = listParametersForGame[2];
            string paper = listParametersForGame[3];
            string scissors = listParametersForGame[4];
            int countWins = int.Parse(listParametersForGame[5]);
            int countLoses = int.Parse(listParametersForGame[6]);
            int countDraws = int.Parse(listParametersForGame[7]);

            if ((playerChoise == rock && computerChoise == scissors)
                           || (playerChoise == paper && computerChoise == rock)
                           || (playerChoise == scissors && computerChoise == paper))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You win!\n");
                countWins++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if ((playerChoise == rock && computerChoise == paper)
                || (playerChoise == paper && computerChoise == scissors)
                || (playerChoise == scissors && computerChoise == rock))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose!\n");
                countLoses++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The game is a draw!\n");
                countDraws++;
                Console.ForegroundColor = ConsoleColor.White;
            }

            listParametersForGame[0] = playerChoise;
            listParametersForGame[1] = computerChoise;
            listParametersForGame[5] = countWins.ToString();
            listParametersForGame[6] = countLoses.ToString();
            listParametersForGame[7] = countDraws.ToString();

            return listParametersForGame;
        }

        public static string ComputerChoiseMethod(int computerNumber, string computerChoise,
            string rock, string paper, string scissors)
        {
            switch (computerNumber)
            {
                case 1:
                    computerChoise = rock;
                    break;
                case 2:
                    computerChoise = paper;
                    break;
                case 3:
                    computerChoise = scissors;
                    break;
            }
            return computerChoise;
        }



        public static void DisplayWinsLoses(int countWins, int countLoses, int countDraws)
        {
            string timesWins = (countWins == 1) ? "time" : "times";
            string timesLose = (countLoses == 1) ? "time" : "times";
            string timesDraw = (countDraws == 1) ? "time" : "times";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You won {countWins} {timesWins} and lose {countLoses} {timesLose}.");
            Console.WriteLine($"You have draw {countDraws} {timesDraw}.");

            int sumAllgames = countWins + countLoses + countDraws;
            double procentWins = (countWins / (double)sumAllgames) * 100;
            double procentLoses = (countLoses / (double)sumAllgames) * 100;

            if (procentWins >= 50)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Well done! You have won a {procentWins:f2}% win rate.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Better luck next time.You have a {procentLoses:f2}% lose rate.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
