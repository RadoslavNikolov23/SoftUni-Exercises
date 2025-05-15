using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRowsCol = int.Parse(Console.ReadLine());

            int[,] squarMatrix = new int[numberRowsCol, numberRowsCol];

            InputSquareMatrix(squarMatrix);

            int[] bombs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

            FindBoms(squarMatrix, bombs);

            int[] activeCellsAndSum = ActiveCells(squarMatrix);
            int activeCellCount = activeCellsAndSum[0];
            int sumCells = activeCellsAndSum[1];

            PrintOutPut(squarMatrix, activeCellCount, sumCells);
        }


        private static void InputSquareMatrix(int[,] squarMatrix)
        {
            for (int i = 0; i < squarMatrix.GetLength(0); i++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int j = 0; j < squarMatrix.GetLength(1); j++)
                {
                    squarMatrix[i, j] = data[j];
                }
            }
        }

        private static void FindBoms(int[,] squarMatrix, int[] bombs)
        {
            for (int b = 0; b < bombs.Length; b++)
            {
                int bomRow = bombs[b];
                int bomCol = bombs[++b];

                for (int i = 0; i < squarMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < squarMatrix.GetLength(1); j++)
                    {
                        if (i == bomRow && j == bomCol)
                        {
                            if (squarMatrix[i, j] > 0)
                            {

                                BombExploed(squarMatrix, i, j);

                                squarMatrix[i, j] = 0;
                            }
                        }
                    }
                }
            }

        }

        private static void BombExploed(int[,] squarMatrix, int i, int j)
        {
            int valueBomb = squarMatrix[i, j];

            if (i - 1 >= 0 && j - 1 >= 0)
            {
                if (CheckValue(squarMatrix[i - 1, j - 1]))
                    squarMatrix[i - 1, j - 1] -= valueBomb;
            }
            if (i - 1 >= 0)
            {
                if (CheckValue(squarMatrix[i - 1, j]))
                    squarMatrix[i - 1, j] -= valueBomb;
            }

            if (i - 1 >= 0 && j + 1 < squarMatrix.GetLength(1))
            {
                if (CheckValue(squarMatrix[i - 1, j + 1]))
                    squarMatrix[i - 1, j + 1] -= valueBomb;
            }

            if (j + 1 < squarMatrix.GetLength(1))
            {
                if (CheckValue(squarMatrix[i, j + 1]))
                    squarMatrix[i, j + 1] -= valueBomb;
            }

            if (i + 1 < squarMatrix.GetLength(0) && j + 1 < squarMatrix.GetLength(1))
            {
                if (CheckValue(squarMatrix[i + 1, j + 1]))
                    squarMatrix[i + 1, j + 1] -= valueBomb;
            }

            if (i + 1 < squarMatrix.GetLength(0))
            {
                if (CheckValue(squarMatrix[i + 1, j]))
                    squarMatrix[i + 1, j] -= valueBomb;
            }

            if (i + 1 < squarMatrix.GetLength(0) && j - 1 >= 0)
            {
                if (CheckValue(squarMatrix[i + 1, j - 1]))
                    squarMatrix[i + 1, j - 1] -= valueBomb;
            }

            if (j - 1 >= 0)
            {
                if (CheckValue(squarMatrix[i, j - 1]))
                    squarMatrix[i, j - 1] -= valueBomb;
            }


        }

        private static bool CheckValue(int value)
        {
            if (value > 0) return true;
            else return false;
        }

        private static int[] ActiveCells(int[,] squarMatrix)
        {

            int counActiveCells = 0;
            int sumCells = 0;
            for (int i = 0; i < squarMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < squarMatrix.GetLength(1); j++)
                {
                    if (squarMatrix[i, j] > 0)
                    {
                        counActiveCells++;
                        sumCells += (squarMatrix[i, j]);
                    }
                }
            }

            int[] array = new int[] { counActiveCells, sumCells };

            return array;
        }

        private static void PrintOutPut(int[,] squarMatrix, int activeCellCount, int sumCells)
        {
            Console.WriteLine($"Alive cells: {activeCellCount}");
            Console.WriteLine($"Sum: {sumCells}");

            for (int i = 0; i < squarMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < squarMatrix.GetLength(1); j++)
                {
                    if (j > 0) Console.Write(" ");
                    Console.Write(squarMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
