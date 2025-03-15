namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.ComponentModel.DataAnnotations;
    using System.Transactions;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbCcontext = new CarDealerContext();
            dbCcontext.Database.Migrate();

            //string filePath = @"..\..\..\Datasets\sales.json";
            //string jsonFile = File.ReadAllText(filePath);

            string result = GetCarsFromMakeToyota(dbCcontext);
            Console.WriteLine(result);
        }


        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carToyota = context
                .Cars
                .Where(c=>c.Make=="Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c=>c.Model)
                .ThenByDescending(c=>c.TraveledDistance)
                .ToArray();



            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new DefaultNamingStrategy()
            };

            string jsonConvert = JsonConvert
                .SerializeObject(carToyota, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = defaultContractResolver
                });

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