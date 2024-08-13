using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberComadns = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentDictionary = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberComadns; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentDictionary.ContainsKey(studentName))
                {
                    studentDictionary.Add(studentName, new List<double>() { grade });
                }
                else
                {
                    studentDictionary[studentName].Add(grade);
                }

            }

            foreach (var student in studentDictionary)
            {
                double avarageGrade = student.Value.Average();
                if (avarageGrade >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {avarageGrade:f2}");

                }
            }


        }
    }
}
