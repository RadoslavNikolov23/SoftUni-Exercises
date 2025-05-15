double[] numbers=Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

for (int i = 0; i < numbers.Length; i++)
{
    double num = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
    Console.WriteLine($"{numbers[i]} => {num}");
}