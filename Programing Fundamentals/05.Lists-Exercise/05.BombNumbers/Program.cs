using System;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> listNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bomb = bombNumber[0];
            int range = Math.Abs(bombNumber[1]);

            for (int i = 0; i < listNumbers.Count; i++)
            {
                if (listNumbers[i] == bomb)
                {
                    int start = i - range;

                    if (start < 0)
                    {
                        start = 0;
                    }

                    int finish = i + range + 1;

                    if (finish > listNumbers.Count)
                    {
                        finish = listNumbers.Count;
                    }
                    for (int j = start; j < finish; j++)
                    {
                        listNumbers.RemoveAt(start);
                    }

                    i--;
                }
            }



            //Console.WriteLine(string.Join(" ",listNumbers));

            int allNumbersSum = 0;
            for (int i = 0; i < listNumbers.Count; i++)
            {
                allNumbersSum += listNumbers[i];
            }
            Console.WriteLine(allNumbersSum);

        }
    }
}
