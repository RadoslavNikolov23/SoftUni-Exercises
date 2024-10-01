namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberPeople=int.Parse(Console.ReadLine());
            List<Person> personList = new List<Person>();

            for (int i = 0; i < numberPeople; i++)
            {
                string[] data=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name=data[0];
                int age=int.Parse(data[1]);

                personList.Add(new Person(name,age));
            }

            foreach(var person in personList.Where(x=>x.Age>30).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }



        }
    }
}
