
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

            string result = GetEmployee147(context);

            Console.WriteLine(result);

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee employee = context.Employees
                .First(e => e.EmployeeId==147);
                
            employee.Projects = context.EmployeesProjects
                .Where(e => e.EmployeeId == 147)
                .Select(e => e.Project)
                .OrderBy(e => e.Name)
                .ToList();


            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach(var project in employee.Projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }

}
