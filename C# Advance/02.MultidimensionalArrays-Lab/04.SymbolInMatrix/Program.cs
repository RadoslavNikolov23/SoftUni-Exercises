using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCols = int.Parse(Console.ReadLine());

            char[,] matrix = InputMatrix(rowCols, rowCols);

            char sumbolToFind = char.Parse(Console.ReadLine());
            bool isFound = false;
            int[] coordOfSumb = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == sumbolToFind)
                    {
                        coordOfSumb[0] = i;
                        coordOfSumb[1] = j;
                        isFound = true;
                        break;
                    }
                }

                if (isFound) break;
            }

            if (isFound)
            {
                Console.WriteLine($"({string.Join(", ",coordOfSumb)})");
            }
            else
            {
                Console.WriteLine($"{sumbolToFind} does not occur in the matrix");
            }
        }

        public static char[,] InputMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] charCol = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = charCol[j];
                }
            }

            return matrix;
        }
    }
}
