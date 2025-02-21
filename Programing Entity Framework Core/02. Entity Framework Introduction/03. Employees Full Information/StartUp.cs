
namespace SoftUni
{
    using SoftUni.Data;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            using SoftUniContext context = new SoftUniContext();

            string result = GetEmployeesFullInformation(context);

            Console.WriteLine(result);

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    MiddleName = e.MiddleName ?? null,
                    e.JobTitle,
                    Salary = e.Salary.ToString("F2")
                })
                .ToList();


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
            }
            return sb.ToString().TrimEnd();

        }
    }


}
