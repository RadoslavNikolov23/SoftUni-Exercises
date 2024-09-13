using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dataRowCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = InputMatrix(dataRowCols[0], dataRowCols[1]);

            WriteSumAllCol(matrix);

        }

        private static void WriteSumAllCol(int[,] matrix)
        {

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sumCol = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sumCol += matrix[i, j];
                }
                    Console.WriteLine(sumCol);
            }

        }

        private static int[,] InputMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] dataRows = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = dataRows[j];
                }

            }

            return matrix;
        }
    }
}
