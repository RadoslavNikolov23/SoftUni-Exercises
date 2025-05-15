using System;

namespace GuessANumberByRadoslav
{
    class ConsoleGame
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int countTries = 0;
            int maxTries=0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Let's play a Game: Guess the Number!");
            Console.WriteLine();

            while (true)
            {
            Game:
                maxTries=EnterTries(maxTries);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Guess a number from 1 to 100, you have only {maxTries} tries");
            
                int numberFromComputer = randomNumber.Next(1, 101);

                GameOn(numberFromComputer,maxTries,countTries);
               
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Would you like to start a new Game - \"yes\" or \"no\"");
                string answerForRestar = Console.ReadLine().ToLower();
                if (answerForRestar == "yes")
                {
                    countTries = 0;
                    Console.WriteLine();
                    goto Game;
                }
                else if (answerForRestar == "no")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over! Bye");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input is Invalid!");
                    Console.WriteLine("Game Over!");
                    Console.WriteLine();
                    break;
                }
            }
        }

        private static int EnterTries(int maxTries)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter how many tries would you like to have: ");
            string inputTries = Console.ReadLine();

            bool gameOn = int.TryParse(inputTries, out maxTries);

            if (!gameOn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! You will have 3 tries!");
                maxTries = 3;
            }
            return maxTries;
        }

        private static void GameOn(int numberFromComputer, int maxTries, int countTries)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Your number is: ");
                string inputByPlayer = Console.ReadLine();

                bool isValid = int.TryParse(inputByPlayer, out int playerNumber);

                if (isValid)
                {
                    if (playerNumber == numberFromComputer)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You guessed it!");
                        Console.WriteLine();
                        break;
                    }
                    else if (playerNumber > numberFromComputer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your Number is too Hight! Try again.");
                        countTries++;
                        if (countTries >= maxTries)
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You have {maxTries - countTries} tries left");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your Number is too Low! Try again.");
                        countTries++;
                        if (countTries >= maxTries)
                        {
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You have {maxTries - countTries} tries left");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input is Invalid! Try again.");
                    countTries++;
                    if (countTries >= maxTries)
                    {
                        break;

                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"You have {maxTries - countTries} tries left");
                    Console.WriteLine();
                }
            }
        }
    }
}
