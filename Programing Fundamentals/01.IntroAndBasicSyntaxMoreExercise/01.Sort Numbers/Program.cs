int number = int.Parse(Console.ReadLine());
int number1 = int.Parse(Console.ReadLine());
int number2 = int.Parse(Console.ReadLine());


int[] numbers = { number, number1, number2 };


Array.Sort(numbers);


Array.Reverse(numbers);


foreach (int num in numbers)
{
    Console.WriteLine(num);
}

int[] rado= { 55, 33, 22 };
foreach (int num in rado)
{
    Console.WriteLine(num);
}


