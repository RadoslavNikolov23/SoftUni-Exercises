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

            string result = GetCarsWithTheirListOfParts(dbCcontext);
            Console.WriteLine(result);
        }


        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carWithPartsList = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts=c.PartsCars.Select(pc => new
                    {
                        pc.Part.Name,
                        Price= pc.Part.Price.ToString("F2")
                    })
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
                .SerializeObject(carWithPartsList, Formatting.Indented);

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