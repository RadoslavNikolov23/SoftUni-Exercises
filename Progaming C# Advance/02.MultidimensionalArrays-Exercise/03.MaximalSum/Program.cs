namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowsMax = rowsAndCols[0], colsMax = rowsAndCols[1];

            int[,] matrix = new int[rowsMax, colsMax];

            matrix = InputMatrix(matrix);

            int[,] rectangularMatrix = new int[3, 3];
            int[,] finalRetacgleMatrix = new int[3, 3];
            int sumRetaclMatrix = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    rectangularMatrix = RetacgleMatrixInput(matrix, i, j);
                    sumRetaclMatrix = GetMaxSum(rectangularMatrix);

                    //sumRetaclMatrix = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                    // + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                    // + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (sumRetaclMatrix > maxSum)
                    {
                        maxSum = sumRetaclMatrix;
                        finalRetacgleMatrix = rectangularMatrix;
                    }
                }
            }


            PrintOutPut(finalRetacgleMatrix, maxSum);

        }

        public static void PrintOutPut(int[,] finalRetacgleMatrix, int maxSum)
        {
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < finalRetacgleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < finalRetacgleMatrix.GetLength(1); j++)
                {
                    if(j>0) Console.Write(" ");
                    Console.Write(finalRetacgleMatrix[i,j]);
                }
                Console.WriteLine();

            }
        }

        public static int GetMaxSum(int[,] rectangularMatrix)
        {
            int sum = 0;

            for (int i = 0; i < rectangularMatrix.GetLength(0); i++)
                for (int j = 0; j < rectangularMatrix.GetLength(1); j++)
                    sum += rectangularMatrix[i, j];

            return sum;
        }

        public static int[,] RetacgleMatrixInput(int[,] matrix, int i, int j)
        {

            int[,] retagleMatrix = new int[3, 3]
            {
               { matrix[i, j],matrix[i, j + 1],matrix[i, j + 2] },
                { matrix[i + 1, j],matrix[i + 1, j + 1],matrix[i + 1, j + 2] },
                { matrix[i + 2, j],matrix[i + 2, j + 1],matrix[i + 2, j + 2] }
            };

            return retagleMatrix;
        }


        public static int[,] InputMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            return matrix;
        }
    }
}
