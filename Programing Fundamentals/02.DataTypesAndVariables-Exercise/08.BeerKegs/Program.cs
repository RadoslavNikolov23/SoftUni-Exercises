int numberLine = int.Parse(Console.ReadLine());

string bestModel = string.Empty;
double bestKeg = 0;

for (int i = 0; i < numberLine; i++)
{
    string model = Console.ReadLine();
    double radius = double.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());

    double currentKeg=(Math.PI*(Math.Pow(radius, 2)))*height;

    if (currentKeg > bestKeg)
    {
        bestModel= model;
        bestKeg=currentKeg;
    }

}
Console.WriteLine(bestModel);