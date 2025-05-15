using System.Diagnostics;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int countOrders=int.Parse(Console.ReadLine());
            bool ordersOver = true;
            int count = 0;
            decimal total = 0;

            while (ordersOver)
            {
                decimal pricePerCapsile = decimal.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());
                decimal totalPrice = ((days * capsuleCount) * pricePerCapsile);
                
                Console.WriteLine($"The price for the coffee is: ${totalPrice:f2}");
                total += totalPrice;
                count++;

                if(count==countOrders)
                {
                    ordersOver = false;
                }
            }

            Console.WriteLine($"Total: ${total:f2}");





        }
    }
}
