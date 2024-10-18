using System.ComponentModel.Design;

namespace _02.ClearSkies;

public class Program
{
    public static void Main()
    {
        int numberRowCol = int.Parse(Console.ReadLine());

        char[,] matrix = new char[numberRowCol, numberRowCol];

        int rowPl = 0, colPl = 0;

        int armor = 300;
        int enemies = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string data = Console.ReadLine();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = data[j];

                if (matrix[i, j] == 'J')
                {
                    rowPl = i;
                    colPl = j;
                }

                if (matrix[i, j] == 'E') enemies++;
            }
        }

        matrix[rowPl, colPl] = '-';
        while (true)
        {
            string command = Console.ReadLine();

            (rowPl,colPl, armor, enemies)= CheckMatrix(matrix,rowPl,colPl,command, armor, enemies);

            if (armor <= 0 || enemies<=0) break;

        }

        matrix[rowPl, colPl] = 'J';

        if(enemies==0) Console.WriteLine($"Mission accomplished, you neutralized the aerial threat!");
        else Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{rowPl}, {colPl}]!");
        PrintMatrix(matrix);
    }
     
    public static (int x, int y, int z, int u) CheckMatrix(char[,] matrix, int rowPl, int colPl, string command, int armor, int enemies)
    {
        switch (command)
        {
            case "up":
                if (rowPl - 1 >= 0)
                {
                    rowPl -= 1;
                    if (matrix[rowPl, colPl] == 'R')
                    {
                        armor = 300;
                        matrix[rowPl, colPl] = '-';
                    }
                    else if (matrix[rowPl, colPl] == 'E')
                    {
                        if (enemies > 0)
                        {
                            armor -= 100;
                            enemies--;
                        } 
                        matrix[rowPl, colPl] = '-';
                    }
                }
             

                    break;
            case "down":
                if (rowPl + 1 < matrix.GetLength(0))
                {
                    rowPl += 1;
                    if (matrix[rowPl, colPl] == 'R')
                    {
                        armor = 300;
                        matrix[rowPl, colPl] = '-';
                    }
                    else if (matrix[rowPl, colPl] == 'E')
                    {
                        if (enemies > 0)
                        {
                            armor -= 100;
                            enemies--;
                        }
                        matrix[rowPl, colPl] = '-';
                    }

                }
                break;
            case "left":
                if (colPl - 1 >= 0)
                {
                    colPl -= 1;
                    if (matrix[rowPl, colPl] == 'R')
                    {
                        armor = 300;
                        matrix[rowPl, colPl] = '-';
                    }
                    else if (matrix[rowPl, colPl] == 'E')
                    {
                        if (enemies > 0)
                        {
                            armor -= 100;
                            enemies--;
                        }
                        matrix[rowPl, colPl] = '-';
                    }

                }
                break;
            case "right":
                if (colPl + 1 < matrix.GetLength(1))
                {
                    colPl += 1;
                    if (matrix[rowPl, colPl] == 'R')
                    {
                        armor = 300;
                        matrix[rowPl, colPl] = '-';
                    }
                    else if (matrix[rowPl, colPl] == 'E')
                    {
                        if (enemies > 0)
                        {
                            armor -= 100;
                            enemies--;
                        }
                        matrix[rowPl, colPl] = '-';
                    }
                }
                break;
        }

        return (rowPl, colPl, armor, enemies);
    }
    
    public static void PrintMatrix(char[,] matrix)
    {
        for(int i = 0;i < matrix.GetLength(0); i++)
        {
            for (int j = 0;j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}
