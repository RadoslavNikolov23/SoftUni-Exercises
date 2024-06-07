int number = int.Parse(Console.ReadLine());

int[] numbers = new int[number];

for (int i = 0; i < number; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
}

for (int i = 0;i < number; i++)
{
    Console.Write(numbers[numbers.Length-1-i]+ " ");
}



