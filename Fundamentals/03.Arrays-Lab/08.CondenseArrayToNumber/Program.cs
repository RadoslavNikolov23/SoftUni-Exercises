
int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();


while (numbers.Length > 1)
{
    int[] sum = new int[numbers.Length-1];

    for (int i = 0; i < sum.Length; i++)
    {
        sum[i] = numbers[i] + numbers[i + 1];
    }
    numbers = sum;
}
Console.WriteLine(numbers[0]);
