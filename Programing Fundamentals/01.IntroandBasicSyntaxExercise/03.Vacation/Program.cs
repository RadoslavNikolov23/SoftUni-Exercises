using System.Diagnostics;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countPeople=int.Parse(Console.ReadLine());
            string typeGroup= Console.ReadLine();
            string dayOfWeek= Console.ReadLine();
            decimal pricePerson = 0;
            decimal totalPrice = 0;

            if (typeGroup == "Students")
            {
                switch (dayOfWeek) 
                {
                    case "Friday":
                        pricePerson = 8.45m;
                        break; 
                    case "Saturday":
                        pricePerson = 9.80m;
                        break;
                    case "Sunday":
                        pricePerson = 10.46m;
                        break;
                }
                totalPrice = pricePerson * countPeople;

                if(countPeople>=30)
                {
                    totalPrice *= 0.85m;
                }

            }
            else if (typeGroup == "Business")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerson = 10.90m;
                        break;
                    case "Saturday":
                        pricePerson = 15.60m;
                        break;
                    case "Sunday":
                        pricePerson = 16m;
                        break;
                }
                totalPrice = pricePerson * countPeople;
               
                if (countPeople >= 100)
                {
                    totalPrice -= (pricePerson*10);
                }

            }
            else if (typeGroup == "Regular")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        pricePerson = 15m;
                        break;
                    case "Saturday":
                        pricePerson = 20m;
                        break;
                    case "Sunday":
                        pricePerson = 22.50m;
                        break;
                }
                totalPrice = pricePerson * countPeople;

                if (countPeople >= 10 && countPeople<=20)
                {
                    totalPrice *= 0.95m;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
