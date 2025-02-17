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
                FirstName = "Gosho",
                LastName = "Inserted",
                DeparmentId = context.Departments.First().Id,
                IsEmployed =true
            });

            Employee employee = context.Employees.Last();
            employee.FirstName = "Modifiel";


            Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.DeparmentId} {employee.IsEmployed}");

            context.SaveChanges();

        }
    }
}
