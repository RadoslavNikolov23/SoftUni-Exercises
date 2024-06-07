using System.Numerics;

int yeild = int.Parse(Console.ReadLine());
int spices = 0;
int days = 0;

if (yeild < 100)
{
    Console.WriteLine(days);
    Console.WriteLine(spices);
}
else
{


    while (yeild >= 100)
    {
        days++;
        spices += yeild;
        spices -= 26;
        yeild -= 10;

    }
    if (yeild >= 26)
    {
        spices -= 26;
    }
    Console.WriteLine(days);
    Console.WriteLine(spices);
}