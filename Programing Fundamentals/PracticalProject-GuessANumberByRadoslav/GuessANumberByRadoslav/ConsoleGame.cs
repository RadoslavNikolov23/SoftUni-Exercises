using System;

namespace GuessANumberByRadoslav
{
    class ConsoleGame
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int numberFromComputer = randomNumber.Next(1, 101);

            while (true)
            {
                Console.WriteLine("Guess a number from 1 to 100: ");
                string inputByPlayer = Console.ReadLine();

                bool isValid = int.TryParse(inputByPlayer, out int playerNumber);

                if (isValid)
                {
                    if (playerNumber == numberFromComputer)
                    {
                        Console.WriteLine("You guessed it!");
                        break;
                    }
                    else if(playerNumber>numberFromComputer)
                    {
                        Console.WriteLine("Your Number is too Hight!");
                    }
                    else
                    {
                        Console.WriteLine("Your Number is too Low!");
                    }
                }
                else
                {
                    Console.WriteLine("Your input is Invalid!");
                }
            }

        }
    }
}
