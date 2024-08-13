namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string outPut=String.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    outPut += array[i];
                }
            }

            Console.WriteLine(outPut);

        }
    }
}
