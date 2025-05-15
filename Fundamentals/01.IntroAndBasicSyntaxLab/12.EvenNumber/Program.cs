namespace _12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool trueCondition = true;

            while (trueCondition)
            {

                if (number % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(number)}");
                    trueCondition=false;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                    number = int.Parse(Console.ReadLine());
                }

                
            }

        }
    }
}
