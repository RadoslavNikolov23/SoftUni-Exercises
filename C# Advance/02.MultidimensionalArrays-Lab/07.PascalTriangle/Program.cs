namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            long numberOfRows = long.Parse(Console.ReadLine());
            long[][] matrixPascal = new long[numberOfRows][];

            for (int i = 0; i < matrixPascal.Length; i++)
            {
                matrixPascal[i] = new long[i + 1];
                if (matrixPascal.Length > 1)
                {
                    matrixPascal[i][0] = 1;
                    matrixPascal[i][^1] = 1;
                }
                else
                {
                    matrixPascal[0][0] = 1;
                }
            }

            for (int i = 2; i < matrixPascal.Length; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    matrixPascal[i][j]=matrixPascal[i-1][j-1]+matrixPascal[i-1][j];

                }
            }

            foreach (long[] row in matrixPascal)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
