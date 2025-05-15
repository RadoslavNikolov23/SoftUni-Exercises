namespace _02.TheGambler;

public class Program
{
    public static void Main()
    {
        int numberRowCol=int.Parse(Console.ReadLine());

        char[,] gameBoard = new char[numberRowCol, numberRowCol];

        int rowG=0, colG=0;
        int amount = 100;

        for(int i = 0; i < numberRowCol; i++)
        {
            string data=Console.ReadLine();
            for(int j = 0; j < numberRowCol; j++)
            {
                gameBoard[i, j] = data[j];
                if(gameBoard[i, j] == 'G')
                {
                    rowG = i;
                    colG = j;
                }
            }
        }

        bool gameEnd = false;
        bool gameWon = false;
        gameBoard[rowG, colG] = '-';
        string command = Console.ReadLine();
        while (command !="end")
        {

            switch (command)
            {
                case "up":
                    if (rowG - 1 < 0) gameEnd = true;
                    else rowG -= 1;
                    break;
                case "down":
                    if (rowG + 1 > gameBoard.GetLength(0)) gameEnd = true;
                    else rowG += 1;
                    break;
                case "left":
                    if (colG - 1 < 0) gameEnd = true;
                    else colG -= 1;
                    break;
                case "right":
                    if (colG + 1 > gameBoard.GetLength(1)) gameEnd = true;
                    else colG += 1;
                    break;
            }

            if (gameBoard[rowG, colG] == 'W') amount += 100;
            if (gameBoard[rowG, colG] == 'P') amount -= 200;
            if (gameBoard[rowG, colG] == 'J')
            {
                amount += 100000;
                gameWon = true;
            }

            if (gameWon) break;

            if (gameEnd || amount <= 0)
            {
                amount = 0;
                break;
            }
          
            command = Console.ReadLine();
            gameBoard[rowG, colG] = '-';

        }

        gameBoard[rowG, colG] = 'G';

        if (gameEnd || amount<=0) Console.WriteLine("Game over! You lost everything!");
        else if (gameWon)
        {
            Console.WriteLine($"You win the Jackpot!");
            Console.WriteLine($"End of the game. Total amount: {amount}$");
        }
        else Console.WriteLine($"End of the game. Total amount: {amount}$");
   
        if(amount > 0) PrintGameBoard(gameBoard);
        
    }



    public static void PrintGameBoard<T>(T[,] gameBoard)
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                Console.Write(gameBoard[i,j]);
            }
            Console.WriteLine();
        }
    }
}
