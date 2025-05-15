namespace _05.MergeSort
{
    public class Program
    {

        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", Mergesort<int>.MergeSortMethod(numbers)));
             
        }

    }
}
