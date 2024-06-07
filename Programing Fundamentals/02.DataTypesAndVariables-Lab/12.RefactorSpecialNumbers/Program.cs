int number = int.Parse(Console.ReadLine());


bool isSpecial = false;

for (int i = 1; i <= number; i++)
{
    int sumAll = 0;
int currNumber = i;
    while (currNumber > 0)
    {
        sumAll += currNumber % 10;
        currNumber /= 10;
    }

    isSpecial = (sumAll == 5) || (sumAll == 7) || (sumAll == 11);
    Console.WriteLine("{0} -> {1}", i, isSpecial);


}
