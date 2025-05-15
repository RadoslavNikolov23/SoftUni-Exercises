using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace EqualityLogic;

public class Program
{
    public static void Main()
    {

        SortedSet<Person> sortPersons= new SortedSet<Person>();
        HashSet<Person> hashPersons= new HashSet<Person>();

        int numberLines = int.Parse(Console.ReadLine());

        while(numberLines > 0)
        {
            string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(data[0], int.Parse(data[1]));

            sortPersons.Add(person);
            hashPersons.Add(person);

            numberLines--;
        }

        Console.WriteLine(sortPersons.Count);
        Console.WriteLine(hashPersons.Count);

    }
}
