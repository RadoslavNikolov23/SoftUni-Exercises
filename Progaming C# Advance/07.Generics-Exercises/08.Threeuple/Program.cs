namespace Threeuple;

public class Program
{
    static void Main()
    {
       
        string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string fullName=string.Join(" ", data.Take(2));
        string address = data[2];
        string town=string.Join(" ", data.Skip(3));

        Tuple<string,string,string> tupleNameAdress=new Tuple<string, string, string>(fullName, address, town);

        data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string name = data[0];
        int litersOfBeer=int.Parse(data[1]);
        string drunkOrNot = data[2];
        Predicate<string> isDrunk = x => x == "drunk";
        Tuple<string,int,bool> tupleBeersDrink=new Tuple<string, int, bool>(name,litersOfBeer,isDrunk(drunkOrNot));

 
        data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        name = data[0];
        double accountBallance=double.Parse(data[1]);
        string bankName = data[2];

        Tuple<string,double,string> tupleBankBalance=new Tuple<string, double, string>(name,accountBallance,bankName);

        Console.WriteLine(tupleNameAdress);
        Console.WriteLine(tupleBeersDrink);
        Console.WriteLine(tupleBankBalance);


    }
}
