using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareNumber = int.Parse(Console.ReadLine());

            char[,] matrix = new char[squareNumber, squareNumber];
            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            InputMatrix(matrix);

            int[] startCoodrinAndCoals = FindCordinAnaCoals(matrix);

            StartJorney(matrix, directions, startCoodrinAndCoals);

            Console.WriteLine();
        }

        public static void StartJorney(char[,] matrix, string[] directions, int[] startCoodrinAndCoals)
        {
            int startRow = startCoodrinAndCoals[0];
            int startCol = startCoodrinAndCoals[1];
            int coalsSum = startCoodrinAndCoals[2];
            int countCollectCoals = 0;
            bool gameOn = true;
            bool foundAllCoal = false;
            bool gameOver = false;

            while (gameOn)
            {
                for(int i = 0; i < directions.Length; i++)
                {
                    switch (directions[i])
                    {
                        case "up":
                            if(startRow-1>=0)
                            {
                                char curnSym = matrix[startRow - 1, startCol];
                                    startRow = startRow - 1;

                                if (curnSym == '*')
                                {
                                    continue;
                                }
                                else if (curnSym == 'c')
                                {
                                    countCollectCoals++;
                                    matrix[startRow, startCol] = '*';
                                    coalsSum--;

                                    if (0 >= coalsSum)
                                    {
                                        gameOn = false;
                                        foundAllCoal = true;
                                    }
                                }
                                else if (curnSym == 'e')
                                {
                                    gameOn = false;
                                    gameOver = true;
                                }
                            }
                            break;

                        case "right":
                            if (startCol+1<matrix.GetLength(1))
                            {
                                char curnSym = matrix[startRow, startCol+1];
                                startCol = startCol + 1;

                                if (curnSym == '*')
                                {
                                    
                                    continue;
                                }
                                else if (curnSym == 'c')
                                {
                                    countCollectCoals++;
                                    matrix[startRow, startCol] = '*';
                                    coalsSum--;

                                    if (0 >= coalsSum)
                                    {
                                        gameOn = false;
                                        foundAllCoal = true;
                                    }
                                }
                                else if (curnSym == 'e')
                                {
                                    gameOn = false;
                                    gameOver = true;
                                }
                            }
                            break;

                        case "left":
                            if (startCol - 1 >=0)
                            {
                                char curnSym = matrix[startRow, startCol - 1];
                                startCol = startCol - 1;

                                if (curnSym == '*')
                                {
                                    continue;
                                }
                                else if (curnSym == 'c')
                                {
                                    countCollectCoals++;
                                    matrix[startRow, startCol] = '*';
                                    coalsSum--;

                                    if (0 >= coalsSum)
                                    {
                                        gameOn = false;
                                        foundAllCoal = true;
                                    }
                                }
                                else if (curnSym == 'e')
                                {
                                    gameOn = false;
                                    gameOver = true;
                                }
                            }
                            break;

                        case "down":
                            if (startRow +1<matrix.GetLength(0))
                            {
                                char curnSym = matrix[startRow+1, startCol];
                                startRow = startRow + 1;

                                if (curnSym == '*')
                                {
                                    continue;
                                }
                                else if (curnSym == 'c')
                                {
                                    countCollectCoals++;
                                    matrix[startRow, startCol] = '*';
                                    coalsSum--;

                                    if (0 >= coalsSum)
                                    {
                                        gameOn = false;
                                        foundAllCoal = true;
                                    }
                                }
                                else if (curnSym == 'e')
                                {
                                    gameOn = false;
                                    gameOver = true;
                                }
                            }
                            break;
                    }

                    if (!gameOn) break;
                }

                if (foundAllCoal)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    gameOn = false;
                }
                else if (gameOver)
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    gameOn = false;
                }
                else
                {
                    Console.WriteLine($"{coalsSum} coals left. ({startRow}, {startCol})");
                    gameOn = false;
                }

            }



        }


        public static int[] FindCordinAnaCoals(char[,] matrix)
        {
            int[] startCoord = new int[3];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        startCoord[0] = i;
                        startCoord[1] = j;
                    }
                    else if (matrix[i, j] == 'c')
                    {
                        startCoord[2]++;
                    }
                }
                
            }

            return startCoord;
        }

        public static void InputMatrix(char[,] matrix)
        {
            for(int i=0; i < matrix.GetLength(0); i++)
            {
                char[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }

            }

        }
    }
}
