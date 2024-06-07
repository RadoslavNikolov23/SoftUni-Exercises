int numberLines = int.Parse(Console.ReadLine());
int finalSum = 0;

for (int i = 0; i < numberLines; i++)
{
    char latinLetter = char.Parse(Console.ReadLine());
    finalSum+= latinLetter;
}
Console.WriteLine($"The sum equals: {finalSum}");