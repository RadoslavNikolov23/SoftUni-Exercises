//Name Price



using System.Diagnostics;

decimal currentBalance=decimal.Parse(Console.ReadLine());
string input = string.Empty;
decimal spent = 0m;


while ((input = Console.ReadLine()) != "Game Time")
{
    decimal price = 0m;
  

    switch(input)
    {
        case "OutFall 4":
            price=39.99m;
            
            if(currentBalance < price)
            {
                Console.WriteLine("Too Expensive");
            }
            else
            {
                currentBalance -= price;
                spent += price;
                Console.WriteLine($"Bought {input}");
            }
            break;

        case "CS: OG":
            price=15.99m;
            if (currentBalance < price)
            {
                Console.WriteLine("Too Expensive");
            }
            else
            {
                currentBalance -= price;
                spent += price;
                Console.WriteLine($"Bought {input}");
            }
            break;

        case "Zplinter Zell":
            price=19.99m;
            if (currentBalance < price)
            {
                Console.WriteLine("Too Expensive");
            }
            else
            {
                currentBalance -= price;
                spent += price;
                Console.WriteLine($"Bought {input}");
            }
            break;

        case "Honored 2":
            price=59.99m;
            if (currentBalance < price)
            {
                Console.WriteLine("Too Expensive");
            }
            else
            {
                currentBalance -= price;
                spent += price;
                Console.WriteLine($"Bought {input}");
            }
            break;

        case "RoverWatch":
            price=29.99m;
            if (currentBalance < price)
            {
                Console.WriteLine("Too Expensive");
            }
            else
            {
                currentBalance -= price;
                spent += price;
                Console.WriteLine($"Bought {input}");
            }
            break;

        case "RoverWatch Origins Edition":
            price=39.99m;
            if (currentBalance < price)
            {
                Console.WriteLine("Too Expensive");
            }
            else
            {
                currentBalance -= price;
                spent += price;
                Console.WriteLine($"Bought {input}");
            }
            break;

        default:
            Console.WriteLine("Not Found");
            break;
    }
    

    if(currentBalance <= 0)
    {
        Console.WriteLine("Out of money!");
        break;
    }
}

if (currentBalance > 0)
    Console.WriteLine($"Total spent: ${spent:f2}. Remaining: ${currentBalance:f2}");
