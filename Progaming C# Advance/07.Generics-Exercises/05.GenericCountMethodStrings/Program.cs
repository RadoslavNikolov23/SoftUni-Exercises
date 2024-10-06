namespace GenericCountMethodStrings;

public class Program
{
    static void Main()
    {

        int numberOfElements = int.Parse(Console.ReadLine());
        List<string> elementsList = new List<string>();

        for(int i=0;i< numberOfElements;i++)
        {
            string input= Console.ReadLine();
            elementsList.Add(input);
        }
        string elementsToCompare = Console.ReadLine();

        
        Console.WriteLine(CompareMethod(elementsList, elementsToCompare));

    }

    private static int CompareMethod<TValue>(List<TValue> list, TValue value) where TValue:IComparable
    {
        int count = 0;

        foreach (TValue item in list)
        {
            if(item.CompareTo(value) > 0) count++;
        }


        return count;

    }
}
