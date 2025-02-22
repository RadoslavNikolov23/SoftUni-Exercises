
namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            using SoftUniContext context = new SoftUniContext();

            string result = AddNewAddressToEmployee(context);

            Console.WriteLine(result);

        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            //StringBuilder sb = new StringBuilder();

            Address address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            Employee nakov = context.Employees.First(e => e.LastName == "Nakov");
            nakov.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();



            return String.Join(Environment.NewLine, employees);
        }
    }

}
