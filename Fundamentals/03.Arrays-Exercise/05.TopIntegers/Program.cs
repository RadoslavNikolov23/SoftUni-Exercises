int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
string result = null;

for (int i = 0; i <= array.Length - 1; i++)
{
    bool topInt = true;
    for (int k = i + 1; k < array.Length; k++)
    {
        if (array[i] <= array[k])
        {
            topInt = false;
        }
    }

    if (topInt)
    {
        result += array[i] + " ";
        
    }

}
Console.Write(result);



