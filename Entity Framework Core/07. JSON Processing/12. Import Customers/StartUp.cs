namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Transactions;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbCcontext = new CarDealerContext();
            dbCcontext.Database.Migrate();

            string filePath = @"..\..\..\Datasets\customers.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportCustomers(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }


        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            string result = "";
            CustomerDTO[]? customerDTOs = JsonConvert
                 .DeserializeObject<CustomerDTO[]>(inputJson);

            if (customerDTOs != null)
            {
                //using var transaction = context.Database.BeginTransaction();
                //try
                //{
                    ICollection<Customer> customersToImport = new List<Customer>();

                    foreach (var custDTO in customerDTOs)
                    {
                        if (IsValid(custDTO))
                        {
                            bool isYoundDriver = false;
                            if (custDTO.IsYoungDriver == "true")
                                isYoundDriver = true;


                            string[] datetimeArray = custDTO.BirthDate!.Split('-');

                            DateTime birthDay = new DateTime(int.Parse(datetimeArray[0]), int.Parse(datetimeArray[1]), int.Parse(datetimeArray[2].Substring(0, 2)));

                            Customer customer = new Customer()
                            {
                                Name = custDTO.Name,
                                BirthDate = birthDay,
                                IsYoungDriver = isYoundDriver
                            };

                            customersToImport.Add(customer);

                        }

                    }

                    context.Customers.AddRange(customersToImport);
                    context.SaveChanges();

                   // transaction.Commit();


                    result = $"Successfully imported {customersToImport.Count}.";

                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Something went wrong: ");
                //    Console.WriteLine(e.InnerException);
                //}

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