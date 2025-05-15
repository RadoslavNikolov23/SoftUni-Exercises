using System;
using System.Linq;

namespace _06.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            Quick.Sort(array);

            Console.WriteLine(string.Join(" ", array));
        }
    }

    public class Quick
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;

            int part = Partition(array, start, end);
            Sort(array, start, part - 1);
            Sort(array, part+1,end);
        }

        private static int Partition<T>(T[] array, int start, int end) where T : IComparable<T>
        {

            if (start >= end) return start;

            int i = start;
            int j = end + 1;

            while (true)
            {

                while (Less(array[++i], array[start]))
                {
                    if (i == end) break;
                }

                while (Less(array[start], array[--j]))
                {
                    if (j == start) break;
                }

                if (i >= j) break;
                Swap(array, i, j);

            }

            Swap(array, start, j);
            return j;
        }

        private static bool Less<T>(T t1, T t2) where T : IComparable<T>
        {
            return t1.CompareTo(t2) < 0;
        }

        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
