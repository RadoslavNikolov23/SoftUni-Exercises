namespace _03.PassedOrFailed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal grade = decimal.Parse(Console.ReadLine());
            if (grade >= 3.00m)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
