namespace _01.BallGame;

public class Program
{
    public static void Main()
    {
        Stack<int> strengthStack = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Queue<int> accuracyQueue = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        int scoredGoals = 0;
        while (strengthStack.Count > 0 && accuracyQueue.Count > 0)
        {
            int lastStrenght = strengthStack.Peek();
            int firstAccurancy = accuracyQueue.Peek();

            int sum = lastStrenght + firstAccurancy;

            if (sum == 100)
            {
                scoredGoals++;
                strengthStack.Pop();
                accuracyQueue.Dequeue();
            }
            else if (sum < 100)
            {
                if (lastStrenght < firstAccurancy) strengthStack.Pop();
                else if (lastStrenght > firstAccurancy) accuracyQueue.Dequeue();
                else
                {
                    strengthStack.Pop();
                    accuracyQueue.Dequeue();
                    strengthStack.Push(sum);
                }
            }
            else if (sum > 100)
            {
                strengthStack.Push(strengthStack.Pop() - 10);
                accuracyQueue.Enqueue(accuracyQueue.Dequeue());
            }

        }

        if (scoredGoals > 3) Console.WriteLine("Paul performed remarkably well!");
        else if (scoredGoals == 3) Console.WriteLine("Paul scored a hat-trick!");
        else if (scoredGoals > 0 && scoredGoals < 3) Console.WriteLine("Paul failed to make a hat-trick.");
        else if (scoredGoals <= 0) Console.WriteLine("Paul failed to score a single goal.");

        if (scoredGoals != 0) Console.WriteLine($"Goals scored: {scoredGoals}");

        if (strengthStack.Count != 0 || accuracyQueue.Count != 0)
        {
            if (strengthStack.Count > 0) Console.WriteLine($"Strength values left: {string.Join(", ", strengthStack)}");
            else if (accuracyQueue.Count > 0) Console.WriteLine($"Accuracy values left: {string.Join(", ", accuracyQueue)}");
        }


    }
}
