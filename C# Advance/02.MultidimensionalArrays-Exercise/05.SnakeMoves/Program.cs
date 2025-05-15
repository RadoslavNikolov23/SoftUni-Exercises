using System.Diagnostics.Metrics;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string input = Console.ReadLine();

            string[,] matrix = new string[rows, cols];
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = input[counter++].ToString();
                       counter= CheckCounterInput(input, counter);
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1)-1; j >=0; j--)
                    {
                        matrix[i, j] = input[counter++].ToString();
                        counter = CheckCounterInput(input, counter);

                    }
                }
            }

            PrintMatrix(matrix);
        }

        public static int CheckCounterInput(string input, int counter)
        {
            if (counter >= input.Length)
                counter = 0;

            return counter;
        }

        public static void PrintMatrix(string[,] matrix)
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
}
