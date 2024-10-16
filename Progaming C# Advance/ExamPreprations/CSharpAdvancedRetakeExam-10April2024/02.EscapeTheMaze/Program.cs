using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.EscapeTheMaze
{
    public class Program
    {
        public static void Main()
        {
            int numberRowCol = int.Parse(Console.ReadLine());

            char[,] matrix = new char[numberRowCol, numberRowCol];

            int rowP = 0, colP = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];

                    if (matrix[i, j] == 'P')
                    {
                        rowP = i;
                        colP = j;
                    }
                }
            }

            int health = 100;
            matrix[rowP, colP] = '-';
            bool reachtTheExit = false;
            while (true)
            {
                string commands = Console.ReadLine();
                (rowP, colP) = GetNewRowAndCol(commands, rowP, colP, matrix);

              
                if (matrix[rowP, colP] == 'M')
                {
                    health -= 40;

                    if (health > 0) matrix[rowP, colP] = '-';
                }

                if (matrix[rowP, colP] == 'H')
                {
                    health += 15;
                    matrix[rowP, colP] = '-';
                    if (health > 100) health = 100;
                }

                if (health <= 0)
                {
                    health = 0;
                    break;
                }
                if (matrix[rowP, colP] == 'X')
                {
                    reachtTheExit = true;
                    break;
                }
            }

            matrix[rowP, colP] = 'P';
            if (health <= 0 && !reachtTheExit) Console.WriteLine($"Player is dead. Maze over!");
            else if (health > 0 && reachtTheExit) Console.WriteLine($"Player escaped the maze. Danger passed!");
            Console.WriteLine($"Player's health: {health} units");

            PrintMatrix(matrix);

        }

        private static (int rowP, int colP) GetNewRowAndCol(string commands, int rowP, int colP, char[,] matrix)
        {
            switch (commands)
            {
                case "up":
                    if (rowP - 1 >= 0) rowP -= 1;
                    break;
                case "down":
                    if (rowP + 1 < matrix.GetLength(0)) rowP += 1;
                    break;
                case "left":
                    if (colP - 1 >= 0) colP -= 1;
                    break;
                case "right":
                    if (colP + 1 < matrix.GetLength(1)) colP += 1;
                    break;
            }

            return (rowP, colP);
        }

        private static void PrintMatrix(char[,] matrix)
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
