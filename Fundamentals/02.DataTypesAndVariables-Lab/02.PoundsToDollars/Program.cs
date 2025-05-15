decimal britishPounds= decimal.Parse(Console.ReadLine());

decimal oneDollar = 1.31m;

decimal usaDollars=britishPounds*oneDollar;

Console.WriteLine($"{usaDollars:f3}");