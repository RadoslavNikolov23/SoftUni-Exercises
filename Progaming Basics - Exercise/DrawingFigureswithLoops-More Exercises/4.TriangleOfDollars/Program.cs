int n = int.Parse(Console.ReadLine());

for (int row = 0; row <= n; row++)
{
    for (int col = 0; col < row; col++)
    {
        Console.Write("$");
    }
    Console.WriteLine();
}
