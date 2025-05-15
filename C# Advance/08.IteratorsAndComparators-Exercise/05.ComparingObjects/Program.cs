namespace ComparingObjects;

public class Program
{
    public static void Main()
    {
        string input=Console.ReadLine();
        List<Person> personList= new List<Person>();

        while (input != "END")
        {
            string[] inputArray=input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
         Person person=new Person(inputArray[0], int.Parse(inputArray[1]), inputArray[2]);   

            personList.Add(person);
            input = Console.ReadLine();
        }
        int numberToCompare=int.Parse(Console.ReadLine());

        Person personToCompare = personList[numberToCompare - 1];
      


        int countMathers = 0;
        int numberNotEqual = 0;

        foreach (Person person in personList)
        { 
            int result= person.CompareTo(personToCompare);

            switch (result) {
                case 1:
                    numberNotEqual++;
                    break;

                case 0:
                    countMathers++;
                    break;

            }
        }

        if (countMathers > 1)
        Console.WriteLine($"{countMathers} {numberNotEqual} {personList.Count}");
        else
            Console.WriteLine("No matches");

    }
}
