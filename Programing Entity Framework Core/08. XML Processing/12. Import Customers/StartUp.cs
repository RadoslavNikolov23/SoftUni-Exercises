namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContex = new CarDealerContext();
            dbContex.Database.Migrate();
            Console.WriteLine("Database successfully been created....");

            string path = @"../../../Datasets/customers.xml";
            string inputXML = File.ReadAllText(path);

            string result = ImportCustomers(dbContex, inputXML);
            Console.WriteLine(result);

        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string result = "";

            ImportCustomerDTO[]? importedCustomersDTO = XmlHelper
                .Desirialize<ImportCustomerDTO[]>(inputXml, "Customers");

            if (importedCustomersDTO != null)
            {
                ICollection<Customer> customersToAdd = new List<Customer>();

                foreach(var customerDTO in importedCustomersDTO)
                {
                    if (!IsValid(customerDTO))
                        continue;

                    bool isBirthDate = DateTime.TryParse(customerDTO.BirthDate,
                                                        out DateTime birthDay);
                    bool isItAYoungDriver = bool.TryParse(customerDTO.IsYoungDriver, out bool isYoungDriver);

                    if (!isBirthDate || !isItAYoungDriver)
                        continue;

                    Customer customer = new Customer()
                    {
                        Name = customerDTO.Name,
                        BirthDate = birthDay,
                        IsYoungDriver = isYoungDriver
                    };

                    customersToAdd.Add(customer);
                }

               context.Customers.AddRange(customersToAdd);
                context.SaveChanges();
                result = @$"Successfully imported {customersToAdd.Count}";
            }
            
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}