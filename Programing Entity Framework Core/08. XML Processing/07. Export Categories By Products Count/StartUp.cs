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

            string result = GetCategoriesByProductsCount(dbContext);
            Console.WriteLine(result);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductsCountDTO[] categoriesByProductsCountDTOs = context
                .Categories
                .Select(c => new
                {
                   c.Name,
                   Count=c.CategoryProducts.Count(),
                   AveragePrice=c.CategoryProducts.Average(cp=>cp.Product.Price),
                   TotalRevenue=c.CategoryProducts.Sum(cp=>cp.Product.Price)
                })
                .OrderByDescending(c=>c.Count)
                .ThenBy(c=>c.TotalRevenue)
                .Select(c=> new ExportCategoriesByProductsCountDTO()
                {
                    Name = c.Name,
                    Count=c.Count.ToString(),
                    AveragePrice=c.AveragePrice.ToString(),
                    TotalRevenue = c.TotalRevenue.ToString()
                })
                .ToArray();

            string result = XmlHelper.Serialize(categoriesByProductsCountDTOs, "Categories");

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