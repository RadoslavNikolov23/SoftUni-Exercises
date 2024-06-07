int n = int.Parse(Console.ReadLine());


for (int i = 1; i <= n; i++)
{
    int currNumber = i;
    int sumDigit = 0;
   
    while (currNumber > 0)
    {
        sumDigit += currNumber % 10;
        currNumber /= 10;
    }

    bool isSpecial = false;

    if (sumDigit== 5 ||  sumDigit== 7 || sumDigit==11)
    {
        isSpecial = true;
    }

    Console.WriteLine($"{i} -> {isSpecial}");
}
