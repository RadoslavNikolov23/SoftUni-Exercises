using System.Xml;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            Console.WriteLine(TaskResult(numberOne, numberTwo, numberThree));
            
        }

         static int TaskResult(int numberOne, int numberTwo, int numberThree)
         {
             return SumFirstAndSecondNumber(numberOne, numberTwo) - numberThree;
         }

        static int SumFirstAndSecondNumber(int numberOne, int numberTwo)
         {
             return numberOne + numberTwo;
         }
    }
}
