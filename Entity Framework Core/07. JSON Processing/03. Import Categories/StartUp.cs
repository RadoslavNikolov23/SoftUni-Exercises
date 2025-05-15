namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbCcontext = new ProductShopContext();
            dbCcontext.Database.Migrate();

            string filePath = @"..\..\..\Datasets\categories.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportCategories(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryDTO[]? importCategoryDTOs = JsonConvert
                .DeserializeObject<ImportCategoryDTO[]>(inputJson);

            if (importCategoryDTOs != null)
            {
                ICollection<Category> categoriesToImport = new List<Category>();

                foreach (ImportCategoryDTO categoryDTO in importCategoryDTOs)
                {
                    if (IsValid(categoryDTO))
                    {
                        if (categoryDTO.Name != null)
                        {
                            Category category = new Category()
                            {
                                Name = categoryDTO.Name
                            };

                            categoriesToImport.Add(category);
                        }
                    }
                }


                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();
                result = $"Successfully imported {categoriesToImport.Count}";
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