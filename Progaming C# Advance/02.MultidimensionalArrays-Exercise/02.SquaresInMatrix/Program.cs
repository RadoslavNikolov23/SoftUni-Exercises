using System.Net.Http.Headers;

namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsMax = rowsAndCols[0], colsMax = rowsAndCols[1];

            string[,] matrix=new string[rowsMax, colsMax];

            matrix=InsertToMatix(matrix);

            int countFoundSquarsInMatrix = FindSquarsInMatrix(matrix);

            Console.WriteLine(countFoundSquarsInMatrix);
        }

        private static int FindSquarsInMatrix(string[,] matrix)
        {
            int countFoundSquarsInMatrix=0;
            for (int i=0;i<matrix.GetLength(0)-1; i++)
            {
                for(int j=0;j<matrix.GetLength(1)-1; j++)
                {
                    string primeSymb = matrix[i,j];
                    if (primeSymb == matrix[i,j+1] 
                        && primeSymb == matrix[i+1,j]
                        && primeSymb == matrix[i + 1, j +1])
                    {
                        countFoundSquarsInMatrix++;
                    }
                }
            }

            return countFoundSquarsInMatrix;
        }

        public static string[,] InsertToMatix(string[,] matrix)
        {
            for (int i = 0;i<matrix.GetLength(0);i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = data[j];
                }
            }

            return matrix;
        }
    }
}
