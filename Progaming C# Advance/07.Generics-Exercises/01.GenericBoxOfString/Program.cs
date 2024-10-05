using _01.GenericBoxOfString;

namespace GenericBoxOfString;

public class Program
{
    static void Main()
    {
        int numberLines=int.Parse(Console.ReadLine());

        List<Box<string>> listOfBoxStrings = new List<Box<string>>();

        for(int i=0;i<numberLines;i++)
        {
            string input=Console.ReadLine();
            listOfBoxStrings.Add(new Box<string>(input));
        }

        foreach(Box<string> box in listOfBoxStrings)
        {
            Console.WriteLine(box.ToString());
        }
    }
}
