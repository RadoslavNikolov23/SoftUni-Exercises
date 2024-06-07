namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int sumEvenNumbers = 0;
            int sumOddNumbers = 0;

            while (number > 0)
            {
                int lastDigit= number % 10;

                if (lastDigit % 2 == 0)
                {
                    sumEvenNumbers= SumEvenNumber(sumEvenNumbers,lastDigit);
                }
                else
                {
                    sumOddNumbers=SumOddNumber(sumOddNumbers,lastDigit);
                }

                number /= 10;
            }

            Console.WriteLine(SummEvenOddNumber(sumEvenNumbers, sumOddNumbers));



            
            static int SumEvenNumber(int sumEvenNumber, int evenNumber)
            {
                return sumEvenNumber += evenNumber;
            }
            

            static int SumOddNumber(int sumOddNumber, int oddNumber)
            {
                return sumOddNumber += oddNumber;
            }

            static int SummEvenOddNumber(int sumEven, int sumOdd)
            {
                return sumEven * sumOdd;
            }
            

        }
    }
}
