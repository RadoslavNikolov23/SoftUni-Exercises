namespace _07.TheatrePromotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayType=Console.ReadLine();
            int age=int.Parse(Console.ReadLine());
            int priceTicket = 0;
            

            if (age >= 0 && age<=18)
            {
                switch (dayType)
                {
                    case "Weekday":
                        priceTicket=12; 
                        break; 
                    case "Weekend":
                        priceTicket=15; 
                        break; 
                    case "Holiday":
                        priceTicket=5; 
                        break;

                }
            }
            else if (age >= 19 && age <= 64)
            {
                switch (dayType)
                {
                    case "Weekday":
                        priceTicket = 18;
                        break;
                    case "Weekend":
                        priceTicket = 20;
                        break;
                    case "Holiday":
                        priceTicket = 12;
                        break;

                }
            }
            else if (age >= 65 && age <= 122)
            {
                switch (dayType)
                {
                    case "Weekday":
                        priceTicket = 12;
                        break;
                    case "Weekend":
                        priceTicket = 15;
                        break;
                    case "Holiday":
                        priceTicket = 10;
                        break;

                }
            
            }

            if (priceTicket != 0)
            {
                Console.WriteLine($"{priceTicket}$");
            }
            else
            {   
                Console.WriteLine("Error!");
            }

           
        }
    }
}
