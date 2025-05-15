
namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal numberOne = decimal.Parse(Console.ReadLine());
            decimal numberTwo = decimal.Parse(Console.ReadLine());

            

            decimal result = FactorialOne(numberOne) / FactorialTwo(numberTwo);
            Console.WriteLine($"{result:f2}");
        }

        private static decimal FactorialTwo(decimal numberTwo)
        {
            decimal factorial = numberTwo;

            if (factorial > 0)
            {
                for (decimal i = factorial - 1; i > 0; i--)
                {
                    factorial *= i;
                }

                return factorial;
            }
            else
            {
                return factorial = 1;
            }
        }

        private static decimal FactorialOne(decimal numberOne)
        {

            decimal factorial = numberOne;
            if (factorial > 0)
            {
                for(decimal i = factorial - 1; i > 0; i--)
                {
                    factorial *= i;
                }

                return factorial;
            }
            else
            {
                return factorial=1;
            }

        }
    }
}
