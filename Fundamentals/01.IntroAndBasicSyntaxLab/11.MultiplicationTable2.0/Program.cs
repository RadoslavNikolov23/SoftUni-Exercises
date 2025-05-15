namespace _11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplayer = int.Parse(Console.ReadLine());
            int sum = 0;

            if (multiplayer > 10)
            {
                sum = multiplayer*number;
                Console.WriteLine($"{number} X {multiplayer} = {sum}");
            }
            else
            {
                for (int i = multiplayer; i <= 10; i++)
                {
                    sum = number * i;
                    Console.WriteLine($"{number} X {i} = {sum}");
                }
            }


        }
    }
}
