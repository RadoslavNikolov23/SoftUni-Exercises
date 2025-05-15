using System.Text;

namespace GenericSwapMethodIntegers;

public class Program
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        List<int> listOfNumbers= new List<int>();

        for(int i=0;i<numberOfLines;i++)
        {
            int number = int.Parse(Console.ReadLine());
            listOfNumbers.Add(number);
        }

        int[] indexArray=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        SwapMethodGenerics(listOfNumbers, indexArray[0], indexArray[1]);

        Console.WriteLine(PrintOutPut(listOfNumbers));
    }

    private static void SwapMethodGenerics<T>(List<T> listOfNumbers, int indexOne, int indexTwo)
    {
        T temp = listOfNumbers[indexOne]!;
        listOfNumbers[indexOne] = listOfNumbers[indexTwo];
        listOfNumbers[indexTwo] = temp;
    }

    private static string PrintOutPut<T>(List<T> list)
    {
        StringBuilder sbReasult = new StringBuilder();

        Type typeOfValue= typeof(T);

        list.ForEach(x=> sbReasult.AppendLine($"{typeOfValue}: {x}"));

        return sbReasult.ToString();
    }
}
