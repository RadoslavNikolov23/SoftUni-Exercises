using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCol = int.Parse(Console.ReadLine());

            int[,] matrix = InputMatrix(rowCol);

            int primarDiagonlSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primarDiagonlSum+= matrix[i, i];
            }
            Console.WriteLine(primarDiagonlSum);

        }

        private static int[,] InputMatrix(int rowCol)
        {
            int[,] matrix = new int[rowCol, rowCol];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] dataCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for(int j=0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = dataCol[j];
                }
            }

            return matrix;
        }
    }
}
