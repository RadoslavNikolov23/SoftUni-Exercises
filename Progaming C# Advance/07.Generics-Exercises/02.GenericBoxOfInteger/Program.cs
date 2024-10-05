namespace GenericBoxOfInteger;

public class Program
{
    static void Main()
    {
        int numberLines=int.Parse(Console.ReadLine());

        List<Box<int>> listOfNumbers= new List<Box<int>>();

        for(int i=0;i<numberLines;i++)
        {
            int number=int.Parse(Console.ReadLine());
            listOfNumbers.Add(new Box<int>(number));
        }

        foreach(Box<int> box in listOfNumbers) Console.WriteLine(box.ToString());
    }
}
