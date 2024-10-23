using System;
using System.Linq;

namespace _01.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch.IndexOf(array,index));
        }
    }

    public class BinarySearch 
    {
        public static int IndexOf(int[] array, int key)
        {
            int startArray = 0;
            int endArray = array.Length - 1;

            while(startArray <= endArray)
            {
                int mid = startArray + (endArray - startArray) / 2;

                if (key < array[mid])
                {
                    endArray = mid - 1;
                }
                else if (key > array[mid])
                {
                    startArray = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

    }
}
