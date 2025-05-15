namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //     Write a method that receives two numbers and an operator, 
            //    calculates the result and returns it. 
            //    You will be given three lines of input. 
            //    The first will be the first number, the second one will be the operator and the last one will be the second number.
            //    The possible operators are: /, *, +and -.

            int numberOne = int.Parse(Console.ReadLine());
            char operatorChar = char.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            Result(numberOne, operatorChar, numberTwo);

            void Result(int numberOne, char operatorChar, int numberTwo)
            {
                switch (operatorChar)
                {
                    case '/':
                        Console.WriteLine(OperatorDivide(numberOne,numberTwo));
                        break; 
                    case '*':
                        Console.WriteLine(OperatorMultiply(numberOne, numberTwo));
                        break; 
                    case '+':
                        Console.WriteLine(OperatorSum(numberOne, numberTwo));
                        break; 
                    case '-':
                        Console.WriteLine(OperatorExtract(numberOne, numberTwo));
                        break;
                }
            }

            static int OperatorDivide(int a, int b)
            {
                return a / b;
            }
            static int OperatorMultiply(int a, int b)
            {
                return a * b;
            }
            static int OperatorSum(int a, int b)
            {
                return a + b;
            }
            static int OperatorExtract(int a, int b)
            {
                return a - b;
            }


        }
    }
}
