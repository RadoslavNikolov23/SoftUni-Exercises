using System;

namespace _07.OrderByAge
{
    class Person
    {
        public string Name;

        public string ID;

        public int Age;

        public Person (string name, string id, string age)
        {
            Name = name;
            ID = id;
            Age = int.Parse(age);

        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Person> personList= new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] intputArray = input.Split();
                string name = intputArray[0];
                string id = intputArray[1];
                string age = intputArray[2];

                Person existId = personList.FirstOrDefault(person => person.ID == id);

                if (existId != null)
                {
                    existId.Age =int.Parse(age) ;
                    existId.Name = name;
                }
                else
                {
                    personList.Add(new Person(name, id, age));

                }

            }

            List<Person> orederListByAge=personList.OrderBy(person=>person.Age).ToList();

            foreach (var person in orederListByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
