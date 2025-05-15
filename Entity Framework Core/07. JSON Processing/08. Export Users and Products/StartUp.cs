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

            string result = GetUsersWithProducts(dbCcontext);
            Console.WriteLine(result);

        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var userWithSoldItems = context.Users
                .Where(u => u.ProductsSold
                        .Any(ps => ps.BuyerId!=null))
                .Select(u => new
                {
                    firstName=u.FirstName,
                    lastName= u.LastName,
                    age=u.Age,
                    soldProducts = new
                    {
                        count= u.ProductsSold
                                .Count(ps=>ps.BuyerId.HasValue),
                        products= u.ProductsSold
                                .Where(ps=>ps.BuyerId.HasValue)
                                .Select(ps => new
                                {
                                    ps.Name,
                                    ps.Price
                                })
                                .ToArray()
                    }

                })
                .ToArray()
                .OrderByDescending(u=>u.soldProducts.count)
                .ToArray();


            var userDTO = new
            {
                usersCount = userWithSoldItems.Length,
                users = userWithSoldItems
            };


            DefaultContractResolver defaultContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()

            };

            string jsonConvert = JsonConvert
                .SerializeObject(userDTO, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = defaultContractResolver,
                    NullValueHandling = NullValueHandling.Ignore
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