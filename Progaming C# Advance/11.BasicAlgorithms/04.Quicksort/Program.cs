namespace _04.Quicksort
{

    public class Program
    {
        public static void Main()
        {
            int[] numbersArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            QuickSortClass<int> sorterArray = new QuickSortClass<int>(numbersArray);

            sorterArray.QuickSort(0, numbersArray.Length - 1);

            Console.WriteLine(string.Join(" ", numbersArray));
        }

        public class QuickSortClass<T> where T : IComparable
        {
            public T[] array;

            public QuickSortClass(T[] array)
            {
                this.array = array;
            }
            public void QuickSort(int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

                int pivot = start;
                int left = start + 1;
                int right = end;

                while (left <= right)
                {
                    if (array[left].CompareTo(array[pivot]) > 0 && array[right].CompareTo(array[pivot]) < 0)
                    {
                        Swap(left, right);
                    }

                    if (array[left].CompareTo(array[pivot]) <= 0)
                    {
                        left++;
                    }

                    if (array[right].CompareTo(array[pivot]) >= 0)
                    {
                        right--;
                    }
                }

                Swap(pivot, right);

                QuickSort(start, right - 1);
                QuickSort(right + 1, end);
            }

            public void Swap(int idx1, int idx2)
            {
                T element = array[idx1];
                array[idx1] = array[idx2];
                array[idx2] = element!;
            }
        }
    }
}