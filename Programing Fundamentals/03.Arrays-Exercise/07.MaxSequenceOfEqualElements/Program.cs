string[] array = Console.ReadLine().Split();
string finalElem = string.Empty;


for (int i = 0; i < array.Length; i++)
{
    string tempElem = string.Empty;

    for (int j = i + 1; j < array.Length; j++)
    {
        if (array[i] == array[j])
        {
            tempElem += array[j]+" ";
            if (tempElem.Length >= finalElem.Length)
            {
                finalElem = tempElem + array[i];
            }
        }
        else
        {
            

            break;
        }

    }

}
Console.WriteLine(finalElem);