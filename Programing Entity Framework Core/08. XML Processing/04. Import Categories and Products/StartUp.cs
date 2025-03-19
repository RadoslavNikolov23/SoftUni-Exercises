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

            string path = @"../../../Datasets/categories-products.xml";
            string filePath = File.ReadAllText(path);

            string result = ImportCategoryProducts(dbContext, filePath);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string result = "";

            ImportCategoryProductDTO[]? categoryProductDTOs = XmlHelper
                .Desirialize<ImportCategoryProductDTO[]>(inputXml, "CategoryProducts");

            if (categoryProductDTOs != null)
            {
                Dictionary<int[], string> idsByEntities = new Dictionary<int[], string>()
                {
                    { context.Categories
                            .Select(c => c.Id)
                            .ToArray() ,
                      "categoriesIds"
                    },
                    { context.Products
                            .Select(p=>p.Id)
                            .ToArray(),
                      "productsIds"
                    }
                };

                ICollection<CategoryProduct> categoryProductsToAdd = new List<CategoryProduct>();

                foreach (var categoryProductDTO in categoryProductDTOs)
                {
                    if (!IsValid(categoryProductDTO))
                        continue;

                    bool isCategoryId = int.TryParse(categoryProductDTO.CategoryId, out int categoryId);
                    bool isProductId = int.TryParse(categoryProductDTO.ProductId, out int productId);

                    if (!isCategoryId && !isProductId)
                        continue;

                    if (!idsByEntities.Any(kvp => kvp.Value == "categoriesIds" && kvp.Key.Contains(categoryId)))
                        continue;


                    if (!idsByEntities.Any(kvp => kvp.Value == "productsIds" && kvp.Key.Contains(productId)))
                        continue;

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId,
                    };
                    categoryProductsToAdd.Add(categoryProduct);
                }

                context.CategoryProducts.AddRange(categoryProductsToAdd);
                context.SaveChanges();
                result = $"Successfully imported {categoryProductsToAdd.Count}";

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