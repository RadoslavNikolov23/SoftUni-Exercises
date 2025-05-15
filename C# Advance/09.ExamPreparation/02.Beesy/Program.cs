namespace _02.Beesy;

public class Program
{
    public static void Main()
    {
        int numberRowCol = int.Parse(Console.ReadLine());

        char[,] matrix = new char[numberRowCol, numberRowCol];

        int rowB = 0, colB = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string data = Console.ReadLine();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = data[j];

                if (matrix[i, j] == 'B')
                {
                    rowB = i;
                    colB = j;
                }
            }
        }

        int unitEnergy = 15;
        int collectNectar = 0;

        bool reachTheHive = false;
        bool isRestoredAlready = true;

        while (true)
        {
            string command = Console.ReadLine();
            unitEnergy--;

            matrix[rowB, colB] = '-';
            switch (command)
            {
                case "up":
                    if (rowB - 1 >= 0) rowB--;
                    else rowB = matrix.GetLength(0) - 1;
                    break;

                case "down":
                    if (rowB + 1 > matrix.GetLength(0) - 1) rowB = 0;
                    else rowB++;
                    break;

                case "left":
                    if (colB - 1 >= 0) colB--;
                    else colB = matrix.GetLength(1) - 1;
                    break;

                case "right":
                    if (colB + 1 > matrix.GetLength(1) - 1) colB = 0;
                    else colB++;
                    break;
            }
           

            if (char.IsDigit(matrix[rowB, colB]))
            {
                collectNectar += int.Parse(matrix[rowB, colB].ToString());
                matrix[rowB, colB] = '-';
            }

            if (matrix[rowB, colB] == 'H')
            {
                reachTheHive = true;
                break;
            }

            if (unitEnergy <= 0)
            {
                if (collectNectar < 30) break;
                else
                {
                    if (isRestoredAlready)
                    {
                        unitEnergy = collectNectar - 30;
                        isRestoredAlready = false;                      
                    }
                    else break;
                }
            }
        }
        matrix[rowB, colB] = 'B';


        if(reachTheHive && collectNectar >= 30)
        {
            Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {unitEnergy}");
        }
        else if (reachTheHive && collectNectar<30)
        {
            Console.WriteLine($"Beesy did not manage to collect enough nectar.");
        }
        else
        {
            Console.WriteLine($"This is the end! Beesy ran out of energy.");
        }

        PrintMatrix(matrix);
    }

    public static void PrintMatrix<T>(T[,] matrix)
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
