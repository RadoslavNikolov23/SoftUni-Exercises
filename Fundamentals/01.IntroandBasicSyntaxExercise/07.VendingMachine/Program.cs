namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal coins = 0;
            decimal sumCoins = 0;

            decimal priceProductNuts = 2.0m;
            decimal priceProductWater = 0.7m;
            decimal priceProductCrisps = 1.5m;
            decimal priceProductSoda = 0.8m;
            decimal priceProductCoke = 1.0m;


            while (input != "Start")
            {
                coins = decimal.Parse(input);

                if (coins == 0.1m)
                {
                    sumCoins += coins;
                }
                else if (coins == 0.2m)
                {
                    sumCoins += coins;
                }
                else if (coins == 0.5m)
                {
                    sumCoins += coins;
                }
                else if (coins == 1m)
                {
                    sumCoins += coins;
                }
                else if (coins == 2m)
                {
                    sumCoins += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                input = Console.ReadLine();
            }

            while ((input = Console.ReadLine()) != "End")
            {
                switch (input)
                {
                    case "Nuts":
                        if (sumCoins >= priceProductNuts)
                        {
                            sumCoins -= priceProductNuts;
                            Console.WriteLine($"Purchased nuts");
                        }
                        else
                            Console.WriteLine("Sorry, not enough money");
                        break;
                    case "Water":
                        if (sumCoins >= priceProductWater)
                        {
                            sumCoins -= priceProductWater;
                            Console.WriteLine($"Purchased water");
                        }
                        else
                            Console.WriteLine("Sorry, not enough money");
                        break;
                    case "Crisps":
                        if (sumCoins >= priceProductCrisps)
                        {
                            sumCoins -= priceProductCrisps;
                            Console.WriteLine($"Purchased crisps");
                        }
                        else
                            Console.WriteLine("Sorry, not enough money");
                        break;
                    case "Soda":
                        if(sumCoins >= priceProductSoda)
                        {
                            sumCoins -= priceProductSoda;
                            Console.WriteLine($"Purchased soda");
                        }
                        else
                            Console.WriteLine("Sorry, not enough money");
                        break;
                    case "Coke":
                        if(sumCoins >= priceProductCoke)
                        {
                            sumCoins -= priceProductCoke;
                            Console.WriteLine($"Purchased coke");
                        }
                        else
                            Console.WriteLine("Sorry, not enough money");
                        break;
                        default: 
                        Console.WriteLine("Invalid product");
                        break;
                }
            }

            Console.WriteLine($"Change: {sumCoins:f2}");



        }
    }
}
