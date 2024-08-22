using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;


namespace _02.OldestFamilyMember
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

     class Family
    {
        public List<Person> listOfPeaple { get; set; } = new List<Person>();

        public void AddPerson(string name, int age)
        {
            Person person = new Person(name, age);

            listOfPeaple.Add(person);
        }

        public Person GetOldest()
        {
            return listOfPeaple.OrderByDescending(m => m.Age).First();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] array = Console.ReadLine().Split();
                string name = array[0];
                int age = int.Parse(array[1]);

                family.AddPerson(name, age);
            }

            Person oldestPerson = family.GetOldest();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");



        }
    }
}
