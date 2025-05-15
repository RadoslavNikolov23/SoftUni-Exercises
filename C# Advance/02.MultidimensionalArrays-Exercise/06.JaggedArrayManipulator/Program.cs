using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[numberRows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            matrix = MultiplyOrDivide(matrix);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (isValid(array, matrix))
                {
                    matrix=CommandAction(array, matrix);
                }
            }

            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static int[][] CommandAction(string[] array, int[][] matrix)
        {
            string firstCommand = array[0];
            int row = int.Parse(array[1]);
            int col = int.Parse(array[2]);
            int value = int.Parse(array[3]);
            switch (firstCommand)
            {
                case "Add":
                    matrix[row][col] += value;
                    break;

                case "Subtract":
                    matrix[row][col] -= value;
                    break;

            }

            return matrix;
        }

        public static bool isValid(string[] array, int[][] matrix)
        {
            if (array.Length != 4)
            {
                return false;
            }

            string firstCommand = array[0];
            if (firstCommand != "Add" && firstCommand != "Subtract")
            {
                return false;
            }

            if ((!int.TryParse(array[1], out int row)) ||
                (!int.TryParse(array[2], out int col)) ||
                (!int.TryParse(array[3], out int value)))
            {
                return false;
            }

            if (matrix.Length <= row || 0>row)
            {
                return false;
            }
            else if (matrix[row].Length <= col || 0>col)
            {
                return false;
            }

            return true;
        }

        public static int[][] MultiplyOrDivide(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;

                    }

                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i + 1][j] /= 2;
                    }
                }
            }

            return matrix;
        }
    }
}
