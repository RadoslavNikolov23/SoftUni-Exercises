
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

            string result = RemoveTown(context);

            Console.WriteLine(result);

        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            var adreses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            var towns = context.Towns
                .Where(t => t.Name == "Seattle")
                .First();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(adreses);
            context.Towns.RemoveRange(towns);

            context.SaveChanges();

            return $"{adreses.Count()} addresses in {towns.Name} were deleted";
        }
    }

}
