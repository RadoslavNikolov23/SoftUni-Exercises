namespace _01.WormsAndHoles;

public class Program
{
    public static void Main()
    {

        Stack<int> worms = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        Queue<int> holes = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        int matches = 0;
        int wormMatches=worms.Count;

        while (holes.Count > 0 && worms.Count > 0)
        {

            int lastWorm = worms.Pop();
            int firstHole = holes.Dequeue();

            if (lastWorm != firstHole)
            {
                lastWorm -= 3;

                if (lastWorm > 0) worms.Push(lastWorm);

            }
            else matches++;

        }

        if (matches != 0) Console.WriteLine($"Matches: {matches}");
        else Console.WriteLine($"There are no matches.");

        if (worms.Count == 0 && matches == wormMatches) Console.WriteLine($"Every worm found a suitable hole!");
        else if (worms.Count == 0) Console.WriteLine($"Worms left: none");
        else Console.WriteLine($"Worms left: {string.Join(", ", worms)}");

        if (holes.Count == 0) Console.WriteLine("Holes left: none");
        else Console.WriteLine($"Holes left: {string.Join(", ", holes)}");

    }
}