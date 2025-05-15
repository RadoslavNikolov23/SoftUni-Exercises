namespace _01.BinaryDigitsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            byte number0or1 = byte.Parse(Console.ReadLine());
            int counter = 0;

            while (true)
            {
                if (number == 0)
                {
                    break;
                }

                int devideOpera = number % 2;

                if (devideOpera == number0or1)
                {
                    counter++;
                }

                number /= 2;

            }

            Console.WriteLine(counter);
        }
    }
}
