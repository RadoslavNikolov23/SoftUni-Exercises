namespace _5.OddTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = 0;


            for (int i = 0; i < array.Length; i++)
            {
                result = result ^ array[i];
            }

            Console.WriteLine(result);
        }
    }
}
