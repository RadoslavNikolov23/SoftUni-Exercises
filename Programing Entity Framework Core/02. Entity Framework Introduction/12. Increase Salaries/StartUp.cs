
namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            using SoftUniContext context = new SoftUniContext();

            string result = IncreaseSalaries(context);

            Console.WriteLine(result);

        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                 .Where(e => e.Department.Name == "Engineering"
                 || e.Department.Name == "Tool Design"
                 || e.Department.Name == "Marketing"
                 || e.Department.Name == "Information Services")
                 .OrderBy(e => e.FirstName)
                 .ThenBy(e => e.LastName)
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     Salary = (e.Salary * 1.12m).ToString("F2")
                 })
                 .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            }
                return sb.ToString().TrimEnd();
        }
    }

}
