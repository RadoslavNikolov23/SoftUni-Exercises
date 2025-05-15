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

            string result = GetProductsInRange(dbContext);
            Console.WriteLine(result);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductInRangeDTO[] exportProductInRangeDTOs = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductInRangeDTO()
                {
                    Name = p.Name,
                    Price=p.Price.ToString(),
                    Buyer = p.BuyerId.HasValue ?
                        p.Buyer.FirstName + " " + p.Buyer.LastName
                        :
                        " ",
                })
                .Take(10)
                .ToArray();


            string result = XmlHelper.Serialize(exportProductInRangeDTOs, "Products");

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