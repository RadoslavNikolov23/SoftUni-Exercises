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

            string filePath = @"..\..\..\Datasets\categories-products.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportCategoryProducts(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoryProductDTO[]? importCategoriesProductsDTOs = JsonConvert
                .DeserializeObject<ImportCategoryProductDTO[]>(inputJson);

            if (importCategoriesProductsDTOs != null)
            {
                ICollection<CategoryProduct> categoriesProductsToImport = new List<CategoryProduct>();

                foreach (ImportCategoryProductDTO categoryProductDTO in importCategoriesProductsDTOs)
                {
                    if (IsValid(categoryProductDTO))
                    {
                        bool isCategoryId = int.TryParse(categoryProductDTO.CategoryId, out int categoryId);
                        bool isProductId = int.TryParse(categoryProductDTO.ProductId, out int productId);

                        if (isCategoryId && isProductId)
                        {
                            CategoryProduct categoryProduct = new CategoryProduct()
                            {
                                CategoryId = categoryId,
                                ProductId = productId
                            };

                            categoriesProductsToImport.Add(categoryProduct);
                        }
                       
                    }
                }


                context.CategoriesProducts.AddRange(categoriesProductsToImport);
                context.SaveChanges();
                result = $"Successfully imported {categoriesProductsToImport.Count}";
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