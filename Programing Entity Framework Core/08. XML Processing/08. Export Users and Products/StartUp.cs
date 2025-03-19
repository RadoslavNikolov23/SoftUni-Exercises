namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.Utilities;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            Console.WriteLine("Databse was created ......");

            //string path = @"../../../Datasets/categories-products.xml";
            //string filePath = File.ReadAllText(path);

            string result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUWPUsersDTO[] exportUWPUsersDTO = context
                .Users
                .Where(u => u.ProductsSold.Count >=1)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(u => new ExportUWPUsersDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age.ToString()!,
                    soldProducts = new ExportUWPUSoldProductsDTO()
                    {
                        Count = u.ProductsSold.Count.ToString(),
                        Products = u.ProductsSold
                                                .OrderByDescending(ps => ps.Price)
                                                .Select(ps => new ExportUWPUSPProductsDTO()
                                                {
                                                    Name = ps.Name,
                                                    Price = ps.Price.ToString()
                                                })
                                                        .ToArray()
                    }
                    
                })
                .ToArray();
                

            ExportUsersWithProductsDTO exportUsersWithProductsDTOs = new ExportUsersWithProductsDTO
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()).ToString(),
                Users = exportUWPUsersDTO
            };


            string result = XmlHelper.Serialize(exportUsersWithProductsDTOs, "Users");

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