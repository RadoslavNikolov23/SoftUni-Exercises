namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rows=int.Parse(Console.ReadLine());
            int[][]matrix=new int[rows][];

            for (int i = 0; i < rows; i++) matrix[i]=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArray=input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = inputArray[0];
                int row=int.Parse(inputArray[1]);
                int col=int.Parse(inputArray[2]);
                int value=int.Parse(inputArray[3]);

                if (IsValid(matrix,row,col, rows))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;
                    case "Subtract":
                        matrix[row][col] -= value;
                        break;
                }

            }

            foreach (int[] row in matrix) 
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }

        private static bool IsValid(int[][] matrix, int row, int col,int numberRows)
        {
            if (row>=numberRows || row<0) return true;
            else if(col>=matrix[row].Length || col<0) return true;
            else return false;

        }
    }
}
