using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = ReadPeoplebyNameAndAge();

            Func<Person, bool> filterByConditionAndAge = CreateFilterByConditionAndAge();
            Action<Person> formatToPrint = CreatePrinterByFormat();
            PrintTheFinalFilteredPeople(personList, filterByConditionAndAge, formatToPrint);

        }
        public static List<Person> ReadPeoplebyNameAndAge()
        {
            int numberLines = int.Parse(Console.ReadLine());
            List<Person> personList = new List<Person>();

            for (int i = 0; i < numberLines; i++)
            {
                string[] array = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
                personList.Add(new Person(array[0], int.Parse(array[1])));
            }
            return personList;
        }
        public static Func<Person, bool> CreateFilterByConditionAndAge()
        {
            string conditionAge = Console.ReadLine();
            int ageTreshold = int.Parse(Console.ReadLine());

            if (conditionAge == "younger")
                return x => x.Age < ageTreshold;
            else
                return x => x.Age >= ageTreshold;
        }
        public static Action<Person> CreatePrinterByFormat()
        {
            string format= Console.ReadLine();
            if (format == "name")
            {
                return x => Console.WriteLine(x.Name);
            }
            else if (format == "age")
            {
                return x => Console.WriteLine(x.Age);
            }
            else
            {
                return x => Console.WriteLine($"{x.Name} - {x.Age}");
            }
        }
        public static void PrintTheFinalFilteredPeople(List<Person> personList, Func<Person, bool> filter, Action<Person> printer)
        {
            personList.Where(filter).ToList().ForEach(printer);
        }
    }
}
