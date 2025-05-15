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

            string result = GetSalesWithAppliedDiscount(dbCcontext);
            Console.WriteLine(result);
        }


        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var firstTenSales = context
                .Sales
                .Take(10)
                .Select(s=> new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName=s.Customer.Name,
                    discount=s.Discount.ToString("F2"),
                    price=s.Car.PartsCars.Sum(pc=>pc.Part.Price).ToString("F2"),
                    priceWithDiscount=(s.Car.PartsCars.Sum(pc => pc.Part.Price)*(1-(s.Discount/100))).ToString("F2")

                })
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
                .SerializeObject(firstTenSales, Formatting.Indented);

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