using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbCcontext = new ProductShopContext();
            dbCcontext.Database.Migrate();

            //string filePath = @"..\..\..\Datasets\users.json";
            //string jsonFile = File.ReadAllText(filePath);

            string result = GetProductsInRange(dbCcontext);
            Console.WriteLine(result);


        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(pr => pr.Price >= 500 && pr.Price <= 1000)
                .OrderBy(pr => pr.Price)
                .Select(pr => new
                {
                    name = pr.Name,
                    price = pr.Price,
                    seller = pr.Seller.FirstName + " " + pr.Seller.LastName
                })
                .ToArray();

            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonConvert = JsonConvert
                .SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
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