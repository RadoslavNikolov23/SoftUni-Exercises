namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberPeople=int.Parse(Console.ReadLine());
            Family familyList = new Family();

            for (int i = 0; i < numberPeople; i++)
            {
                string[] data=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name=data[0];
                int age=int.Parse(data[1]);

                Person person=new Person(name,age);
                familyList.AddMember(person);
            }

            Person oldestPerson=familyList.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
         
            

        }
    }
}
