namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNUmber(numberOne, numberTwo, numberThree));
            


        }

        static int SmallestNUmber(int numberOne, int numberTwo, int numberThree)
        {
            if (numberOne < numberTwo && numberOne < numberThree)
            {
                return numberOne;

            }
            else if (numberTwo < numberOne && numberTwo < numberThree)
            {
                return numberTwo;
            }
            else //if (numberThree > numberTwo && numberThree > numberOne)
            {
                return numberThree;

            }

        }

    }
}
