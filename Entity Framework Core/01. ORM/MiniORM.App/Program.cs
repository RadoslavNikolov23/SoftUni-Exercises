using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

namespace MiniORM.App
{
    public class Program
    {
        static void Main()
        {
            string connectionString = "Server=.;Database=MiniORM;Integrated Security=True;Encrypt=False";

            SoftUniDbContextClass context = new SoftUniDbContextClass(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Rado",
                LastName = "Iliev",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            Employee employee = context.Employees.Last();
          


            Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.DepartmentId} {employee.IsEmployed}");

            context.SaveChanges();

        }
    }
}
