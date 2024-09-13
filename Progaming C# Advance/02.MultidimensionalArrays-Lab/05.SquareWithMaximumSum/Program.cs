using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayRowCol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[arrayRowCol[0], arrayRowCol[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] dataColo= Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = dataColo[j];
                }
            }

            int[,] cube = new int[2, 2];
            int maxSumCube = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                int sumTemp = 0;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    sumTemp = matrix[i, j] + matrix[i, j + 1] + matrix[i+1, j] + matrix[i + 1, j + 1];

                    if (sumTemp > maxSumCube)
                    {
                        maxSumCube = sumTemp;
                        cube[0, 0] = matrix[i,j];
                        cube[0, 1] = matrix[i, j+1];
                        cube[1, 0] = matrix[i + 1, j];
                        cube[1, 1] = matrix[i+1, j + 1];
                    }
                }

            }


            Console.WriteLine($"{cube[0, 0]} {cube[0, 1]}");

            Console.WriteLine($"{cube[1, 0]} {cube[1, 1]}");

            Console.WriteLine(maxSumCube);

        }

    }
}
