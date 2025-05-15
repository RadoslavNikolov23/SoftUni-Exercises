namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	A string, representing a product -"coffee",  "water", "coke", "snacks"
            //    •	An integer, representing the quantity of the product

            string input = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CheckProductQuantity(input, quantity);

            void CheckProductQuantity(string input, int n)
            {
                int product = n;
                switch (input)
                {
                    case "coffee":
                        Console.WriteLine($"{ChechCoffe(product):f2}");
                        break;
                    case "water":
                        Console.WriteLine($"{ChechWater(product):f2}");
                        break;
                    case "coke":
                        Console.WriteLine($"{ChechCoke(product):f2}"); 
                        break;
                    case "snacks":
                        Console.WriteLine($"{ChechSnacks(product):f2}");
                        break;
                }
            }

            static double ChechCoffe(int product)
            {
                return product * 1.50;
            }
            static double ChechWater(int product)
            {
                return product * 1.00;
            }
            static double ChechCoke(int product)
            {
                return product * 1.40;
            }
            static double ChechSnacks(int product)
            {
                return product * 2.00;
            }




        }
    }
}
