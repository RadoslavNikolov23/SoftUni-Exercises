using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence_LIS_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] lis;
            int[] len = new int[arrayIntegers.Length];
            int[] prev = new int[arrayIntegers.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < arrayIntegers.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (arrayIntegers[j] < arrayIntegers[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }
            lis = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                lis[i] = arrayIntegers[lastIndex];
                lastIndex = prev[lastIndex];
            }
            Array.Reverse(lis);
            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
