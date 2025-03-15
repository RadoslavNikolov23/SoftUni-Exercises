namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Transactions;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbCcontext = new CarDealerContext();
            dbCcontext.Database.Migrate();

            //string filePath = @"..\..\..\Datasets\sales.json";
            //string jsonFile = File.ReadAllText(filePath);

            string result = GetTotalSalesByCustomer(dbCcontext);
            Console.WriteLine(result);
        }


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithSales = context
                .Customers
                .Where(c => c.Sales.Count>0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars=c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(s=>s.Car.PartsCars).Sum(pc=>pc.Part.Price)

                })
                .OrderByDescending(c=>c.spentMoney)
                .ThenByDescending(c=>c.boughtCars)
                .ToArray();



            //DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            //{
            //    NamingStrategy = new DefaultNamingStrategy()
            //};

            //string jsonConvert = JsonConvert
            //    .SerializeObject(supplierLocal, Formatting.Indented, new JsonSerializerSettings()
            //    {
            //        ContractResolver = defaultContractResolver
            //    });  
            
          
            string jsonConvert = JsonConvert
                .SerializeObject(customersWithSales, Formatting.Indented);

            return jsonConvert;
        }



        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}