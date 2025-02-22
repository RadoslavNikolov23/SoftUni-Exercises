
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

            string result = DeleteProjectById(context);

            Console.WriteLine(result);

        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeesProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            var project=context.Projects
                .Where(p => p.ProjectId == 2)
                .First();

            context.EmployeesProjects.RemoveRange(employeesProjects);
            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => p.Name);   

            return String.Join(Environment.NewLine, projects);
        }
    }

}
