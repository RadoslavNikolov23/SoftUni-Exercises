int numberWagons = int.Parse(Console.ReadLine());

int[] arrayWagons = new int[numberWagons];
int sumPassangers = 0;

for (int i = 0; i < numberWagons; i++)
{
    int pasengers = int.Parse(Console.ReadLine());
    arrayWagons[i] = pasengers;
    sumPassangers += pasengers;
}

Console.WriteLine(string.Join(" ", arrayWagons));
Console.WriteLine(sumPassangers);


