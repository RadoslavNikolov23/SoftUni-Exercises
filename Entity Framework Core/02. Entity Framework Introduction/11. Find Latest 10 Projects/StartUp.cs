
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

            string result = GetLatestProjects(context);

            Console.WriteLine(result);

        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate.Year)
                .ThenByDescending(p => p.StartDate.Month)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }
    }

}
