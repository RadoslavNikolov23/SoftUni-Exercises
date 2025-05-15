
namespace SoftUni
{
    using SoftUni.Data;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            using SoftUniContext context = new SoftUniContext();

            string result = GetEmployeesWithSalaryOver50000(context);

            Console.WriteLine(result);

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    Salary = e.Salary.ToString("F2")
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary}");
            }

            return sb.ToString().TrimEnd();

        }
    }


}
