namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data;
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

            string path = @"../../../Datasets/categories.xml";
            string filePath = File.ReadAllText(path);

            string result = ImportCategories(dbContext, filePath);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string result = "";

            ImportCategoryDTO[]? categoriesDTO = XmlHelper
                .Desirialize<ImportCategoryDTO[]>(inputXml, "Categories");

            if (categoriesDTO != null)
            {
                ICollection<Category> categoriesToAdd = new List<Category>();

                foreach(var categoryDTO in categoriesDTO)
                {
                    if (!IsValid(categoryDTO))
                        continue;

                    if (categoryDTO.Name == "null" || string.IsNullOrEmpty(categoryDTO.Name))
                        continue;

                    Category category = new Category()
                    {
                        Name = categoryDTO.Name
                    };
                    categoriesToAdd.Add(category);
                }



                 context.Categories.AddRange(categoriesToAdd);
                 context.SaveChanges();
                result = $"Successfully imported {categoriesToAdd.Count}";

             }
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