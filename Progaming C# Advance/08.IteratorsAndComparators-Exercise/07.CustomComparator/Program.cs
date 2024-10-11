namespace CustomComparator
{
    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            Array.Sort(array);

            Func<int[], int[]> customsSorterEvenandOdd = num =>
            {
                List<int> newArrayEven = new List<int>();
                List<int> newArrayOdd = new List<int>();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0)
                        newArrayEven.Add(num[i]);
                    else
                        newArrayOdd.Add(num[i]);

                }
                int[] finalArray=newArrayEven.Concat(newArrayOdd).ToArray();
                return finalArray;
            };


          // array=customsSorterEvenandOdd(array);
            Console.WriteLine(string.Join(" ", customsSorterEvenandOdd(array)));



        }
    }
}
