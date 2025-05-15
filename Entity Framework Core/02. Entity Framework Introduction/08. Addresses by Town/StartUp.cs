
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

            string result = GetAddressesByTown(context);

            Console.WriteLine(result);

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                })
                .Take(10)
                .ToArray();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

                return sb.ToString().TrimEnd();
        }
    }

}
