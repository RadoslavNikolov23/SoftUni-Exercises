using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        class Order
        {
            public string Customer;
            public string Product;
            public int Count;
            public decimal Price;
            public Order(string customer, string product, int count, decimal price)
            {
                Customer = customer;
                Product = product;
                Count = count;
                Price = price;
            }

            public decimal Total
            {
                get { return Price * Count; }
            }
        }
        static void Main(string[] args)
        {
            string pattern = @"([^|$%.])*?\%(?<Customer>[A-Z][a-z]+)\%([^|$%.])*?\<(?<Product>\w+)\>([^|$%.])*?\|([^|$%.])*?(?<Count>\d+)([^|$%.])*?\|([^|$%.])*?(?<Price>\d+|\d+.\d+)([^|$%.])*?\$";
            string input;

            List<Order> orderList = new List<Order>();
            decimal totalIncome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                foreach (Match orderMatch in Regex.Matches(input, pattern))
                {
                    orderList.Add(new Order
                        (orderMatch.Groups["Customer"].Value,
                        orderMatch.Groups["Product"].Value,
                        int.Parse(orderMatch.Groups["Count"].Value),
                        decimal.Parse(orderMatch.Groups["Price"].Value)));
                }
            }

            foreach (var order in orderList)
            {
                Console.WriteLine($"{order.Customer}: {order.Product} - {order.Total:f2}");
                totalIncome += order.Total;
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");

        }
    }
}
