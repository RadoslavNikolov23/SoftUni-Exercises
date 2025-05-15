using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace _04.Students
{
    class Student
    {
        public string FirstName;
        public string LastName;
        public double Grade;
        public Student(string firstName,string lastName, string grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = double.Parse(grade);
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberStudents = int.Parse(Console.ReadLine());
            List<Student> studenList = new List<Student>();

            for (int i = 1; i <= numberStudents; i++)
            {
                string[] arrayStudents = Console.ReadLine().Split(" ");
                string firstName = arrayStudents[0];
                string lastName = arrayStudents[1];
                string grade = arrayStudents[2];

                studenList.Add(new Student(firstName, lastName, grade));
            }

            List<Student> orderByGradeList = studenList.OrderByDescending(grade => grade.Grade)
                .ToList();

            foreach (var student in orderByGradeList)
            {
                Console.WriteLine(student);
            }



        }
    }
}
