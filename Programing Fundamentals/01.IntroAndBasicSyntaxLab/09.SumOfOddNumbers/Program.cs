namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumAllNumbers = 0;
            int counter = 0;

            for (int i = 1; i <= 100; i++)
            {
              
                if(i%2!=0)
                {
                    Console.WriteLine(i);
                    sumAllNumbers += i;
                    counter++;
                }

                if (counter == number)
                    break;

               
            }
            Console.WriteLine($"Sum: {sumAllNumbers}");


        }
    }
}
