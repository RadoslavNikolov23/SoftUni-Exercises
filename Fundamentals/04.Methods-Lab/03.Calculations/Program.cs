namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string firstLine = Console.ReadLine();

            int firstNumber = int.Parse(Console.ReadLine());
            int SecondNumber = int.Parse(Console.ReadLine());

            CheckCalculation(firstLine, firstNumber, SecondNumber);
            void CheckCalculation(string line, int a, int b)
            {
                if (line == "add")
                {
                    Console.WriteLine(AddCalculation(a, b));

                }
                else if (line == "multiply")
                {
                    Console.WriteLine(MultiplyCalculation(a, b));
                }
                else if (line == "subtract")
                {
                    Console.WriteLine(SubstractCalculation(a, b));

                }
                else if (line == "divide")
                {

                    Console.WriteLine(DivideCalculation(a, b));
                }
            }

            static int AddCalculation(int a, int b)
            {
                return a + b;
            }

            static int MultiplyCalculation(int a, int b)
            {
                return a * b;
            }

            static int SubstractCalculation(int a, int b)
            {
                return a - b;
            }
            static int DivideCalculation(int a, int b)
            {
                return a / b;
            }
        }
    }
}
