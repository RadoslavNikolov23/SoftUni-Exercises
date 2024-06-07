namespace _04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours=int.Parse(Console.ReadLine());    
            int minutes=int.Parse(Console.ReadLine());

            int addMinutes = minutes+30;

            if (addMinutes >= 60)
            {
                hours++;
                if(hours>=24)
                {
                    hours = 0;
                }
                addMinutes -= 60;
            }

            Console.WriteLine($"{hours}:{addMinutes:d2}");
        }
    }
}
