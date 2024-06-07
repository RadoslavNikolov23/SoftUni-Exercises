string[] array = Console.ReadLine().Split();
string[] tempArray = new string[array.Length];
int rotation = int.Parse(Console.ReadLine());


for (int i = 0; i < rotation; i++)
{
    string curIndex = array[0];

    for (int j = 1; j <= array.Length - 1; j++)
    {
        tempArray[j-1] = array[j];
       
        // array[j] = array[array.Length-1- j];
    }
    array= tempArray;
    array[array.Length-1] = curIndex;

}
Console.WriteLine(string.Join(" ",array));