
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

            string result = GetEmployeesInPeriod(context);

            Console.WriteLine(result);

        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    EmployeesProjects = e.EmployeesProjects
                                        .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                                        .Select(ep => new
                                        {
                                            ep.Project.Name,
                                            StartDate=ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                            EndDate = ep.Project.EndDate.HasValue 
                                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                                        })
                })
                .Take(10)
                .ToArray();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach(var project in emp.EmployeesProjects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }

                return sb.ToString().TrimEnd();
        }
    }

}
