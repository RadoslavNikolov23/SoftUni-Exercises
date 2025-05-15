using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayRowCol = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = arrayRowCol[0];
            int cols= arrayRowCol[1];
            int[,] matrix = GetMatrix(rows, cols);

            int summAllEments=GetSumMatrixElements(matrix);
           
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(summAllEments);
        }

        public static int GetSumMatrixElements(int[,] matrix)
        {
            int sumAllElements = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    sumAllElements += matrix[i, j];
                }
            }
          return sumAllElements;
        }

        public static int[,] GetMatrix(int rows,int cols)
        {
            int[,] matrix = new int[rows, cols];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] dataColon = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = dataColon[j];
                }
            }
            return matrix;
        }
    }
}
