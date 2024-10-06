using System.Diagnostics;

namespace GenericSwapMethodStrings;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfLine=int.Parse(Console.ReadLine());
        List<string>linesOfStrings= new List<string>();

        for(int i=0; i<numberOfLine;i++)
        {
            string input = Console.ReadLine();
            linesOfStrings.Add(input);

        }

        int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        SwapMethod(linesOfStrings, data[0], data[1]);


    }

    public static void SwapMethod<T>(List<T> list,int indexOne, int indexTwo)
    {
        T temp = list[indexOne];
        list[indexOne] = list[indexTwo];
        list[indexTwo]= temp;

        Type type = typeof(T);

        foreach (T text in list)
        {
            Console.WriteLine($"{type}: {text}");
        }

       
    }
}
