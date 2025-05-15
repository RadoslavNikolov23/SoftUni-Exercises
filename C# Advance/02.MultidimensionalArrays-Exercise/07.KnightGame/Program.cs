using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[,] matrix = new string[rows, rows];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j].ToString();
                }
            }

            int finalKnigths = 0;
            bool noMoreKnightsToRemove = true;

            while (noMoreKnightsToRemove)
            {
                int correctRow = 0;
                int correctCol = 0;
                int counRemoveKnights = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == "K")
                        {
                            int tempCounterRemovedKnigts = CheckKnighs(matrix, i, j);


                            if (tempCounterRemovedKnigts > counRemoveKnights)
                            {
                                counRemoveKnights = tempCounterRemovedKnigts;
                                correctRow = i;
                                correctCol = j;
                            }
                        }
                    }
                }

                if (counRemoveKnights > 0)
                {
                    matrix[correctRow, correctCol] = "O";
                    finalKnigths++;
                }
                else
                {
                    noMoreKnightsToRemove = false;
                }

            }


            Console.WriteLine(finalKnigths);



        }

        public static int CheckKnighs(string[,] matrix, int i, int j)
        {
            int counRemoveKnights=0;
            if (i - 2 > -1 && j - 1 > -1)
            {
                if (matrix[i - 2, j - 1] == "K")
                {
                    counRemoveKnights++;
                }
            }

            if (i - 2 > -1 && j + 1 < matrix.GetLength(1))
            {
                if (matrix[i - 2, j + 1] == "K")
                {
                    counRemoveKnights++;
                }
            }

            if (i - 1 > -1 && j + 2 < matrix.GetLength(1))
            {
                if (matrix[i - 1, j + 2] == "K")
                {
                    counRemoveKnights++;
                }
            }

            if (i + 1 < matrix.GetLength(0) && j + 2 < matrix.GetLength(1))
            {
                if (matrix[i + 1, j + 2] == "K")
                {
                    counRemoveKnights++;
                }
            }

            if (i + 2 < matrix.GetLength(0) && j - 1 > -1)
            {
                if (matrix[i + 2, j - 1] == "K")
                {
                    counRemoveKnights++;
                }
            }


            if (i + 2 < matrix.GetLength(0) && j + 1 < matrix.GetLength(1))
            {
                if (matrix[i + 2, j + 1] == "K")
                {
                    counRemoveKnights++;
                }
            }

            if (i - 1 > -1 && j - 2 > -1)
            {
                if (matrix[i - 1, j - 2] == "K")
                {
                    counRemoveKnights++;
                }
            }


            if (i + 1 < matrix.GetLength(0) && j - 2 > -1)
            {
                if (matrix[i + 1, j - 2] == "K")
                {
                    counRemoveKnights++;
                }
            }

            return counRemoveKnights;
        }
    }
}
