using System.Drawing;

namespace _02.BombHasBeenPlanted;

public class Program
{
    public static void Main(string[] args)
    {
        int[] numberRowCol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        char[,] matrix = new char[numberRowCol[0], numberRowCol[1]];

        int rowCT = 0, colCT = 0;
        int rowBomb = 0, colBomb = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = input[j];

                if (matrix[i, j] == 'C')
                {
                    rowCT = i;
                    colCT = j;
                }
            }
        }
        int origRowCT = rowCT, origcolCT = colCT;

        int timeLeft = 16;

        matrix[origRowCT, origcolCT] = '*';
        while (true)
        {
            string command = Console.ReadLine();

            if (timeLeft <= 0)
            {
                Console.WriteLine("Terrorists win!");
                Console.WriteLine("Bomb was not defused successfully!");
                Console.WriteLine($"Time needed: {Math.Abs(timeLeft)} second/s.");
                break;
            }

            if (command == "defuse")
            {
                if (matrix[rowCT, colCT] == 'B')
                {
                    timeLeft -= 4;
                    if (timeLeft >=0 )
                    {
                        matrix[rowCT, colCT] = 'D';
                                               Console.WriteLine("Counter-terrorist wins!");
                        Console.WriteLine($"Bomb has been defused: {timeLeft} second/s remaining.");
                        break;
                    }
                    else
                    {
                        matrix[rowCT, colCT] = 'X';
                        Console.WriteLine("Terrorists win!");
                        Console.WriteLine("Bomb was not defused successfully!");
                        Console.WriteLine($"Time needed: {Math.Abs(timeLeft)} second/s.");
                        break;
                    }
                }
                else
                {
                    timeLeft -= 2;
                    continue;
                }
            }
            else
            {
                if (timeLeft > 0) 
                (rowCT, colCT) = ChechCommand(matrix, rowCT, colCT, command);
                timeLeft--;
            }

        


            if (matrix[rowCT, colCT] == 'T')
            {
                matrix[rowCT, colCT] = '*';
                Console.WriteLine("Terrorists win!");
                break;
            }

         

        }



       matrix[origRowCT,origcolCT]= 'C';

        PrintMatrix(matrix);

    }

    private static (int rowCT, int colCT) ChechCommand(char[,] matrix, int rowCT, int colCT, string? command)
    {
        switch (command)
        {
            case "up":
                if (rowCT - 1 >= 0) rowCT--;
                break;
            case "down":
                if (rowCT + 1 < matrix.GetLength(0)) rowCT++;
                break;
            case "left":
                if (colCT - 1 >= 0) colCT--;
                break;
            case "right":
                if (colCT + 1 < matrix.GetLength(1)) colCT++;
                break;
        }

        return (rowCT, colCT);
    }


    private static void PrintMatrix<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }

    }
}
