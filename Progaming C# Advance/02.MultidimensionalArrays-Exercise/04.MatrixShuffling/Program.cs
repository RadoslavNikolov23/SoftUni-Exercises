using System.Runtime.InteropServices;

namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int maxRow = inputDimensions[0];
            int maxCol = inputDimensions[1];

            string[,] matrix = new string[maxRow, maxCol];

            matrix = ReadMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (!CheckValidInput(input, matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string[] arrayInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int orignRow = int.Parse(arrayInput[1]);
                int orignCol = int.Parse(arrayInput[2]);
                int newRow = int.Parse(arrayInput[3]);
                int newCol = int.Parse(arrayInput[4]);

                //First option:
                /*string tempValue = matrix[orignRow, orignCol];
                 matrix[orignRow, orignCol] = matrix[newRow, newCol];
                 matrix[newRow, newCol] = tempValue;*/

                //Second option:
                (matrix[orignRow, orignCol], matrix[newRow, newCol]) = (matrix[newRow, newCol], matrix[orignRow, orignCol]);

                Pring(matrix);
            }
            Console.WriteLine();
        }

        private static void Pring(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > 0) Console.Write(" ");
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckValidInput(string input, string[,] matrix)
        {
            bool isValid = true;
            string[] arrayInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstCommand = arrayInput[0];


            if (matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1)
            {
                isValid = false;
                return isValid;
            }

            if (arrayInput.Length != 5)
            {
                isValid = false;
                return isValid;
            }
            if (!int.TryParse(arrayInput[1], out int rowOne) ||
                 !int.TryParse(arrayInput[2], out int colOne) ||
                 !int.TryParse(arrayInput[3], out int rowTwo) ||
                 !int.TryParse(arrayInput[4], out int colTwo))
            {
                isValid = false;
                return isValid;
            }

            if (firstCommand != "swap")
            {
                isValid = false;
            }
            else if (matrix.GetLength(0) < rowOne || matrix.GetLength(0) < rowTwo
                     || matrix.GetLength(1) < colOne || matrix.GetLength(1) < colTwo)
            {
                isValid = false;
            }

            return isValid;
        }

        public static string[,] ReadMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            return matrix;
        }
    }
}
