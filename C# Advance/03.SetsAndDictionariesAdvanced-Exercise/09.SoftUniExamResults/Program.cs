using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    public class Student
    {
        public Student(string username, string language, int points)
        {
            Username = username;
            Language = language;
            Points = points;
        }

        public string Username { get; set; }
        public string Language { get; set; }
        public int Points { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, List<int>> submissionDT = new Dictionary<string, List<int>>();
            Dictionary<string, Student> studentDT  = new Dictionary<string, Student>();

            while(input!= "exam finished")
            {
                string[] array = input.Split("-",StringSplitOptions.RemoveEmptyEntries);
             
                string username =string.Empty;
                string language = string.Empty;
                int points = 0;
                if (array.Length >= 3)
                {
                    username = array[0];
                    language = array[1];
                    points = int.Parse(array[2]);

                    Student student = new Student(username, language, points);
                    if (!studentDT.ContainsKey(username)) studentDT[username] = student;
                    else if (studentDT[username].Points < student.Points) studentDT[username].Points = points;
                    if (!submissionDT.ContainsKey(language)) submissionDT[language] = new List<int>() { 1 };
                    else submissionDT[language].Add(1);
                }
                else
                {
                    username = array[0];
                    studentDT.Remove(username);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach(var student in studentDT.OrderByDescending(x=>x.Value.Points).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value.Points}");
            }
            Console.WriteLine("Submissions:");
            foreach(var student in submissionDT.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} - {student.Value.Count}");
            }

        }
    }
}
