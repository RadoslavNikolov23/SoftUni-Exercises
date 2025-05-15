using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MergeSort;

public class Mergesort<T> where T : IComparable<T>
{

    public static T[] MergeSortMethod(T[] array)
    {
        if (array.Length <= 1) return array;

        T[] left = array.Take(array.Length / 2).ToArray();
        T[] right = array.Skip(array.Length / 2).ToArray();

        return Merge(MergeSortMethod(left), MergeSortMethod(right));
    }

    public static T[] Merge(T[] left, T[] right)
    {
        T[] mergedArray = new T[left.Length + right.Length];

        int mergeIndex = 0;
        int leftIndex = 0;
        int rightIndex = 0;

        while ((int)leftIndex < left.Length && (int)rightIndex < right.Length)
        {
            if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
            {
                mergedArray[mergeIndex++] = left[leftIndex++];
            }
            else
            {
                mergedArray[mergeIndex++] = right[rightIndex++];
            }
        }

        while (leftIndex < left.Length)
        {
            mergedArray[mergeIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Length)
        {
            mergedArray[mergeIndex++] = right[rightIndex++];
        }

        return mergedArray;
    }
}
