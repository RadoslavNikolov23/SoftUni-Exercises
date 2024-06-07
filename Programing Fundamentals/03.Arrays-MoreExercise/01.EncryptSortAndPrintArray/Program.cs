int numberStrings=int.Parse(Console.ReadLine());
string[] arrayNames = new string[numberStrings];


for (int i = 0; i < numberStrings; i++)
{
    string names = Console.ReadLine();
    arrayNames[i] = names;    

}

int[] summNames = new int[numberStrings];
int index = 0;
foreach (string name in arrayNames)
{

    int sumVowel = 0;
    int sumConsonant = 0;
    for (int i = 0;i < name.Length; i++)
    {
        if (name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u' ||
            name[i] == 'A' || name[i] == 'E' || name[i] == 'I' || name[i] == 'O' || name[i] == 'U')
        {
            sumVowel+=name[i]*name.Length;
        }
        else //if (name[i] >= 'a' && name[i] <= 'z' || name[i] >= 'A' && name[i] <= 'Z')
            sumConsonant += name[i] / name.Length;
    }

    int sumAll=sumVowel+ sumConsonant;
    
    summNames[index] = sumAll;
    index++;

}
//Console.WriteLine(string.Join(" ",summNames)); ///Delete and the END



Array.Sort(summNames);
foreach (int number in summNames)
{
    Console.WriteLine(number);
}






