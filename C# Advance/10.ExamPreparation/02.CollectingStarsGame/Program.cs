namespace _02.CollectingStarsGame;

public class Program
{
    public static void Main()
    {
        int nRowCol = int.Parse(Console.ReadLine());
        char[,] matrix = new char[nRowCol, nRowCol];

        int rowPlayer = 0, colPlayer = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            char[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = data[j];
                if (matrix[i, j] == 'P')
                {
                    rowPlayer = i;
                    colPlayer = j;
                }
            }
        }

        matrix[rowPlayer, colPlayer] = '.';
        int starsCollect = 2;

        while (true)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "up":
                    if (rowPlayer - 1 < 0)
                    {
                        rowPlayer = 0;
                        colPlayer = 0;
                    }
                    else
                    {
                        if (ChechForObstacle(matrix, rowPlayer - 1, colPlayer)) starsCollect--;
                        else rowPlayer--;
                    }
                    break;

                case "down":
                    if (rowPlayer + 1 > matrix.GetLength(0) - 1)
                    {
                        rowPlayer = 0;
                        colPlayer = 0;
                    }

                    else
                    {
                        if (ChechForObstacle(matrix, rowPlayer + 1, colPlayer)) starsCollect--;
                        else rowPlayer++;
                    }
                    break;

                case "left":
                    if (colPlayer - 1 < 0)
                    {
                        rowPlayer = 0;
                        colPlayer = 0;
                    }
                    else
                    {
                        if (ChechForObstacle(matrix, rowPlayer, colPlayer - 1)) starsCollect--;
                        else colPlayer--;
                    }
                    break;

                case "right":
                    if (colPlayer + 1 > matrix.GetLength(1) - 1)
                    {
                        rowPlayer = 0;
                        colPlayer = 0;
                    }
                    else
                    {
                        if (ChechForObstacle(matrix, rowPlayer, colPlayer + 1)) starsCollect--;
                        else colPlayer++;
                    }
                    break;
            }

            if (matrix[rowPlayer, colPlayer] == '*')
            {
                starsCollect++;
                matrix[rowPlayer, colPlayer] = '.';
            }

            if (starsCollect >= 10) break;

            if (starsCollect <= 0) break;
        }

        matrix[rowPlayer, colPlayer] = 'P';

        if (starsCollect>=10) Console.WriteLine("You won! You have collected 10 stars.");
        else Console.WriteLine("Game over! You are out of any stars.");

        Console.WriteLine($"Your final position is [{rowPlayer}, {colPlayer}]");

        PrintMatrix(matrix);
       
    }

    private static void PrintMatrix<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j > 0) Console.Write(" ");
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static bool ChechForObstacle<T>(T[,] matrix, int row, int col)
    {
        if (matrix[row, col] is '#') return true;
        else return false;

    }
}
