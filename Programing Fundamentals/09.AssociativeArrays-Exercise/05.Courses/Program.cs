using System;
using System.Linq;
using System.Collections.Generic;


namespace _05.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseDictionary = new Dictionary<string, List<string>>();
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] array = command.Split(" : ");
                string courseName = array[0];
                string strudentName = array[1];

                if (!courseDictionary.ContainsKey(courseName))
                {
                    courseDictionary.Add(courseName, new List<string>() { strudentName });
                }
                else
                {
                    courseDictionary[courseName].Add(strudentName);
                }

            }

            foreach (var course in courseDictionary)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }

        }
    }
}
