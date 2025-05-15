namespace Tuple;

public class Program
{
    static void Main()
    {
        
        string[] dataOne=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
        string fullName = string.Join(" ",dataOne.Take(2));
        string adress = dataOne[2];
        Tuple<string, string> nameTuple = new Tuple<string, string>(fullName,adress);


        string[] dataTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Tuple<string, int> beerPerName = new Tuple<string, int>(dataTwo[0], int.Parse(dataTwo[1]));

        string[] dataThree = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Tuple<int, double> intToDouble = new Tuple<int, double>(int.Parse(dataThree[0]),double.Parse(dataThree[1]));
        



        Console.WriteLine(nameTuple);
        Console.WriteLine(beerPerName);
        Console.WriteLine(intToDouble);


    }
}
