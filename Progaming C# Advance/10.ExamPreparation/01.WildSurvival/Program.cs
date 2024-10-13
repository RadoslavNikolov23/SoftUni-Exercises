namespace _01.WildSurvival;

public class Program
{
    public static void Main()
    {
        Queue<int> bees = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        Stack<int> beeEaters = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

       // int remainingBeeEaters = 0;
        while (bees.Count > 0 && beeEaters.Count > 0)
        {
            int firstBees = bees.Dequeue();
            int lastBeeEaters = beeEaters.Pop() * 7;
           // remainingBeeEaters = 0;

            if (lastBeeEaters> firstBees)
            {
                int killedBE = firstBees / 7;

                int remainingBeeEaters=((lastBeeEaters / 7)-killedBE);

                if(beeEaters.Count==0) beeEaters.Push( remainingBeeEaters);
               else beeEaters.Push(beeEaters.Pop()+remainingBeeEaters);
            }
            else if(lastBeeEaters< firstBees)
            {
                bees.Enqueue(firstBees - lastBeeEaters);
            }
        }

        Console.WriteLine("The final battle is over!");
        if(bees.Count==0 && beeEaters.Count == 0)
        {
            Console.WriteLine("But no one made it out alive!");
        }
        else if(bees.Count!=0 && beeEaters.Count == 0)
        {
            Console.WriteLine($"Bee groups left: {string.Join(", ",bees)}");
        }
        else if(bees.Count==0 && beeEaters.Count != 0)
        {
            Console.WriteLine($"Bee-eater groups left: {string.Join(", ", beeEaters)}");
        }
    }
}
