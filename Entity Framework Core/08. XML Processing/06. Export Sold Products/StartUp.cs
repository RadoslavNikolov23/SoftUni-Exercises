namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using ProductShop.Utilities;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            Console.WriteLine("Databse was created ......");

            //string path = @"../../../Datasets/categories-products.xml";
            //string filePath = File.ReadAllText(path);

            string result = GetSoldProducts(dbContext);
            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportSoldProductsDTO[] soldProductsDTOs = context
                .Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new ExportSoldProductsDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold= u.ProductsSold
                                    .Select(ps => new ExportedSoldProductsNamesDTO()
                                    {
                                        Name= ps.Name,
                                        Price=ps.Price.ToString()
                                    })
                                    .ToArray()
                
                })
                .Take(5)
                .ToArray();


            string result = XmlHelper.Serialize(soldProductsDTOs, "Users");

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