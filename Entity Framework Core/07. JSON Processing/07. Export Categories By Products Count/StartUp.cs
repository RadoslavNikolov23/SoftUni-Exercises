using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

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

            string result = GetCategoriesByProductsCount(dbCcontext);
            Console.WriteLine(result);

        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProduct = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts
                        .Select(cp => cp.ProductId)
                        .Count(),
                    averagePrice = c.CategoriesProducts
                        .Average(cp => cp.Product.Price)
                        .ToString("F2"),
                    totalRevenue = c.CategoriesProducts
                        .Sum(cp => cp.Product.Price)
                        .ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();




            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonConvert = JsonConvert
                .SerializeObject(categoriesByProduct, Formatting.Indented, new JsonSerializerSettings()
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