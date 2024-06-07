string[] arrayOne = Console.ReadLine().Split();
string[] arrayTwo = Console.ReadLine().Split();
//string[] arrayFinal = new string[arrayTwo.Length];
string finalSumbols = string.Empty;


for (int i = 0; i < arrayTwo.Length; i++)
{
	for (int j = 0; j < arrayOne.Length; j++)
	{
		if (arrayTwo[i] == arrayOne[j])
		{
			//arrayFinal[i] = arrayTwo[i];
			finalSumbols += arrayTwo[i];
			finalSumbols += " ";

		}
	}
}


//Console.WriteLine(string.Join(" ", arrayFinal));
Console.WriteLine(finalSumbols);
