int waterTankMax=255;

int numberLine = int.Parse(Console.ReadLine());
int currentWater = 0;

for (int i = 0; i < numberLine; i++)
{
    int literInput = int.Parse(Console.ReadLine());
    currentWater += literInput;

    if (currentWater > waterTankMax)
    {
        currentWater -= literInput;
        Console.WriteLine("Insufficient capacity!");
    }

}
Console.WriteLine(currentWater);