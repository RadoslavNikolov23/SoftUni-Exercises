int number = int.Parse(Console.ReadLine());

int[] arrayOne = new int[number];
int[] arrayTwo = new int[number];
int[] currArray = new int[2];

for (int i = 0; i < number; i++)
{
    currArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    if (i % 2 == 0)
    {
        arrayOne[i] = currArray[0];
        arrayTwo[i] = currArray[1];
    }
    else
    {
        arrayOne[i] = currArray[1];
        arrayTwo[i] = currArray[0];
    }
}

Console.WriteLine(string.Join(" ", arrayOne));
Console.WriteLine(string.Join(" ", arrayTwo));