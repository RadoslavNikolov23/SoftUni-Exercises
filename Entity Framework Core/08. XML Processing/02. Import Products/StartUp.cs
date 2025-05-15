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

            string path = @"../../../Datasets/products.xml";
            string filePath = File.ReadAllText(path);

            string result = ImportProducts(dbContext, filePath);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string result = "";

            ImportProductDTO[]? productDTOs = XmlHelper
                .Desirialize<ImportProductDTO[]>(inputXml, "Products");

            if (productDTOs != null)
            {
                ICollection<Product> productsToAdd = new List<Product>();

                foreach (var productDTO in productDTOs)
                {
                    int? buyerId = null;
                    if (!IsValid(productDTO))
                        continue;

                    bool isPrice = decimal.TryParse(productDTO.Price, out decimal price);
                    bool isSellerId = int.TryParse(productDTO.SellerId, out int sellerId);

                    if (!isPrice || !isSellerId)
                        continue;

                    if (productDTO.BuyerId != null)
                    {
                        bool isBuyerId = int.TryParse(productDTO.BuyerId, out int parsedBuyerId);

                        buyerId = parsedBuyerId;

                        if (!isBuyerId)
                            continue;
                    }

                    Product product = new Product()
                    {
                        Name = productDTO.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    productsToAdd.Add(product);
                }



                context.Products.AddRange(productsToAdd);
                context.SaveChanges();
                result = $"Successfully imported {productsToAdd.Count}";

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