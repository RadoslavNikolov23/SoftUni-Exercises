namespace _01.ChickenSnack;

public class Program
{
    public static void Main()
    {
        Stack<int> amountOfMoney = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        Queue<int> priceOfFood = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        int countEatenFood = 0;

        while (amountOfMoney.Count > 0 && priceOfFood.Count > 0)
        {
            int lastMoney = amountOfMoney.Pop();
            int firstFood = priceOfFood.Dequeue();

            if (lastMoney > firstFood)
            {
                int change = lastMoney - firstFood;

                if (amountOfMoney.Count == 0) amountOfMoney.Push(change);
                else amountOfMoney.Push(amountOfMoney.Pop() + change);
                countEatenFood++;

            }
            else if ( lastMoney == firstFood) countEatenFood++;

        }
      

        if (countEatenFood == 0) Console.WriteLine($"Henry remained hungry. He will try next weekend again.");
        else if (countEatenFood >= 4) Console.WriteLine($"Gluttony of the day! Henry ate {countEatenFood} foods.");
        else if (countEatenFood == 1) Console.WriteLine($"Henry ate: {countEatenFood} food.");
        else Console.WriteLine($"Henry ate: {countEatenFood} foods.");


    }
}
