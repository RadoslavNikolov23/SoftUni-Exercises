namespace Froggy;

public class Program
{
    static void Main()
    {
        Lake numbers = new Lake(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList());

        List<int> finalNumbers = new List<int>();

        for (int i = 0; i < numbers.Count(); i += 2)
        {
            finalNumbers.Add(numbers.MyList[i]);
        }

        Func<int, int> FindReverStart=num=>{ if (num % 2 == 0) return num - 1; else return num - 2; };

        for (int i = FindReverStart(numbers.Count()); i >= 0; i -= 2)
        {
            finalNumbers.Add(numbers.MyList[i]);
        }

        Console.WriteLine(string.Join(", ", finalNumbers));



    }
}
