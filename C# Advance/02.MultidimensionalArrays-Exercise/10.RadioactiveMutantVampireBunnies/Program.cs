using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] rowsAndCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];

            int[] starPossion = InputMatrix(matrix);

            string movesString = Console.ReadLine();
            Queue<char> movesQU = new Queue<char>();

            foreach (char letter in movesString)
            {
                movesQU.Enqueue(letter);
            }

            InitialisTheBunnyies(matrix, movesQU, starPossion);
        }

        public static int[] InputMatrix(char[,] matrix)
        {
            int[] starPossition = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string data = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                    if (matrix[i, j] == 'P')
                    {
                        starPossition[0] = i;
                        starPossition[1] = j;
                    }
                }
            }

            return starPossition;
        }
        public static void InitialisTheBunnyies(char[,] matrix, Queue<char> movesQU, int[] starPossion)
        {
            bool initialisTask = true;
            bool playerReachOut = false;
            bool gameOverPlayerDead = false;
            int starRow = starPossion[0];
            int starCol = starPossion[1];
            int[] playerCoordin = new int[2];

            while (initialisTask)
            {
                char command = movesQU.Dequeue();
                matrix[starRow, starCol] = '.';
                playerCoordin[0] = starRow;
                playerCoordin[1] = starCol;

                switch (command)
                {
                    case 'L':
                        starCol -= 1;
                        break;
                    case 'R':
                        starCol += 1;
                        break;
                    case 'U':
                        starRow -= 1;
                        break;
                    case 'D':
                        starRow += 1;
                        break;
                }

                Queue<int> bunniesCord = FindBunnies(matrix);

                while (bunniesCord.Count > 0)
                {
                    int row = bunniesCord.Dequeue();
                    int col = bunniesCord.Dequeue();

                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] == 'P')
                        {
                            gameOverPlayerDead = true;
                            initialisTask = false;
                        }
                        matrix[row, col - 1] = 'B';
                    }

                    if (col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col + 1] == 'P')
                        {
                            gameOverPlayerDead = true;
                            initialisTask = false;
                        }
                        matrix[row, col + 1] = 'B';
                    }

                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] == 'P')
                        {
                            gameOverPlayerDead = true;
                            initialisTask = false;
                        }
                        matrix[row - 1, col] = 'B';
                    }

                    if (row + 1 < matrix.GetLength(0))
                    {
                        if (matrix[row + 1, col] == 'P')
                        {
                            gameOverPlayerDead = true;
                            initialisTask = false;
                        }
                        matrix[row + 1, col] = 'B';
                    }
                }

                if (starRow >= 0 && starRow < matrix.GetLength(0) &&
                    starCol >= 0 && starCol < matrix.GetLength(1))
                {
                    switch (matrix[starRow, starCol])
                    {
                        case 'B':
                            gameOverPlayerDead = true;
                            initialisTask = false;
                            break;

                        case '.':
                            matrix[starRow, starCol] = 'P';
                            break;
                    }
                }
                else
                {
                    initialisTask = false;
                    playerReachOut = true;
                }

                if (movesQU.Count == 0 || playerReachOut)
                    initialisTask = false;
                

                if (gameOverPlayerDead)
                    initialisTask = false;
            }

            PrintIOutPut(matrix, playerReachOut, playerCoordin, starRow, starCol);
        }

        public static Queue<int> FindBunnies(char[,] matrix)
        {
            Queue<int> bunniesCordinats = new Queue<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bunniesCordinats.Enqueue(i);
                        bunniesCordinats.Enqueue(j);
                    }
                }
            }

            return bunniesCordinats;
        }
        public static void PrintIOutPut(char[,] matrix, bool playerReachOut,
            int[] playerCoordinates, int starRow, int starCol)
        {
            int row = playerCoordinates[0];
            int col = playerCoordinates[1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

            if (playerReachOut)
            {
                Console.WriteLine($"won: {row} {col}");
            }
            else
            {
                Console.WriteLine($"dead: {starRow} {starCol}");
            }
        }

    }
}
