namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }

            int sumDiagLeft = 0;
            int sumDiagRight = 0;

            for(int i=0;i < matrix.GetLength(0); i++)
            {
                sumDiagLeft += matrix[i, i];
            }

            int coutRow = 0;
            for(int j=matrix.GetLength(1)-1; j >= 0; j--)
            {
                sumDiagRight += matrix[coutRow++, j];
            }

            Console.WriteLine(Math.Abs(sumDiagLeft-sumDiagRight));

        }
    }
}
