using System.Diagnostics;

namespace IteratorsAndComparators;

public class Program
{
    public static void Main()
    {
        string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Debug.Assert(data[0] == "Create");

        ListyIterator<string> listyList = new ListyIterator<string>(data[1..].ToList());

        string commands = Console.ReadLine();
        while (commands != "END")
        {
            try
            {
                switch (commands)
                {
                    case "Move":
                        Console.WriteLine(listyList.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyList.HasNext());
                        break;
                    case "Print":
                        listyList.Print();
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            
            commands = Console.ReadLine();

        }
    }
}
