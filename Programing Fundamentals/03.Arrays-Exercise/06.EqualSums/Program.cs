int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
bool equal = true;

if (array.Length == 1)
{
    Console.WriteLine(0);
}
else
{
    for (int i = 0; i < array.Length; i++)
    {
        int sumLeft = 0;
        int sumRight = 0;

        for (int j = array.Length - 1; j > i; j--)
        {
            sumRight += array[j];
        }

        for (int j = 0; j < i; j++)
        {
            sumLeft += array[j];
        }

        if (sumRight == sumLeft)
        {
            Console.WriteLine(i);
            equal = false;
        }

    }
}

if(equal && array.Length > 1)
Console.WriteLine("no");