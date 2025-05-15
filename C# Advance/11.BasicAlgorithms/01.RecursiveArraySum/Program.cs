namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int sumAll = SumAllElemets(array);
            Console.WriteLine(sumAll);
        }

        private static int SumAllElemets(int[] array, int index=0, int sum=0)
        {
           
            if (index >= array.Length) return 0;

            sum += array[index]+SumAllElemets(array,index+1);
            return sum;
        }
    }
}
