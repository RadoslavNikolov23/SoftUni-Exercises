namespace GenericCountMethodDoubles;

public class Program
{
    static void Main()
    {

        int numberOfElements = int.Parse(Console.ReadLine());
        List<double> elementsList = new List<double>();

        for (int i = 0; i < numberOfElements; i++)
        {
            double input = double.Parse(Console.ReadLine());
            elementsList.Add(input);
        }
        double elementsToCompare = double.Parse(Console.ReadLine());


        Console.WriteLine(CompareMethod(elementsList, elementsToCompare));

    }

    private static int CompareMethod<TValue>(List<TValue> list, TValue value) where TValue : IComparable
    {
        int count = 0;

        foreach (TValue item in list)
        {
            if (item.CompareTo(value) > 0) count++;
        }


        return count;

    }
}
