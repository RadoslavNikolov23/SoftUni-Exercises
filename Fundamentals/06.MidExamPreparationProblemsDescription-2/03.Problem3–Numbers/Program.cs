using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Problem3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> listFinal = new List<int>();

            int sumValue = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumValue += array[i];
            }

            double avarageValue = sumValue / (double)array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > avarageValue)
                {
                    listFinal.Add(array[i]);
                }

            }
            listFinal.Sort();
            listFinal.Reverse();


            if (listFinal.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = 0; i < listFinal.Count; i++)
                {
                    if (i >= 5)
                    {
                        break;
                    }
                    Console.Write(listFinal[i]+" ");

                }
            }

        }
    }
}
