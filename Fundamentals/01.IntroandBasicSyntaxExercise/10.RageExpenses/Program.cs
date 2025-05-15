namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displaytPrice = double.Parse(Console.ReadLine());

            double totalHeadset = 0;
            double totalMouse = 0;
            double totalKeyboard = 0;
            double totalDisplay = 0;

            if (lostGames >= 2)
            {
                totalHeadset=(lostGames/2)*headsetPrice;
            }

            if (lostGames >= 3)
            {
                totalMouse = (lostGames / 3) * mousePrice;

                if (lostGames >= 2 && lostGames >= 3)
                {
                    totalKeyboard = (lostGames / 6) * keyboardPrice;

                    if(totalKeyboard / 6 > 1)
                    {
                        totalDisplay= (lostGames / 12)*displaytPrice;
                    }
                }

            }

            double totalPrice =totalHeadset+totalMouse+totalKeyboard+totalDisplay;

            Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");



        }
    }
}
