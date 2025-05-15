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

            string result = GetLocalSuppliers(dbCcontext);
            Console.WriteLine(result);
        }


        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplierLocal = context
                .Suppliers
                .Where(s=>s.IsImporter==false)
                .Select(s=> new
                {
                    s.Id,
                    s.Name,
                    PartsCount=s.Parts.Count
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
                .SerializeObject(supplierLocal, Formatting.Indented);

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