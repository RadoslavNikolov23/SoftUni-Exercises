namespace _02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number=int.Parse(Console.ReadLine());

            Console.WriteLine(FactorialOf(number));
        }

        private static int FactorialOf(int number)
        {
            if (number == 1) return 1;

            number *= FactorialOf(number - 1);
            return number;
        }
    }
}
