using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _01.CompanyRoster
{
  class Employee
    {
        public Employee(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberLine = int.Parse(Console.ReadLine());
            List<Employee> listOfEmploeys = new List<Employee>();

            for (int i = 0; i < numberLine; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                double salary = double.Parse(input[1]);
                string deparment = input[2];

                listOfEmploeys.Add(new Employee(name, salary, deparment));

            }


            string highestPaidDeparment = string.Empty;
            double maxSalary = int.MinValue;


            var avarageSalary = listOfEmploeys.GroupBy(em => em.Department)
                                                .Select(x => new { Department = x.Key, 
                                                                   Avg = x.Average(a => a.Salary)});

            foreach (var employee in avarageSalary)
            {
                if (employee.Avg > maxSalary)
                {
                    highestPaidDeparment = employee.Department;
                    maxSalary = employee.Avg;
                }

            }

            List <Employee> highestPaid = new List<Employee>();

            foreach (var emploee in listOfEmploeys)
            {
                if (emploee.Department == highestPaidDeparment)
                {
                    highestPaid.Add(emploee);
                }

            }
            highestPaid = highestPaid.OrderByDescending(x => x.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {highestPaidDeparment}");
            foreach (var empoleyy in highestPaid)
            {
                Console.WriteLine($"{empoleyy.Name} {empoleyy.Salary:f2}");

            }

        }
    }
}
