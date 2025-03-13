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

            string filePath = @"..\..\..\Datasets\products.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportProducts(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportProductDTO[]? importProductDTOs = JsonConvert
                .DeserializeObject<ImportProductDTO[]>(inputJson);

            if (importProductDTOs != null)
            {
                ICollection<Product> productsToImport = new List<Product>();

                foreach (ImportProductDTO productDTO in importProductDTOs)
                {
                    if (IsValid(productDTO))
                    {
                        bool isPrice=Decimal.TryParse(productDTO.Price, out decimal price);
                        bool isSellerId=int.TryParse(productDTO.SellerId, out int sellerId);
                        int? buyerId = null;

                        if (!isPrice || !isSellerId)
                            continue;

                        if (productDTO.BuyerId != null)
                        {
                            bool isBuyerId=int.TryParse(productDTO.BuyerId, out int parsedBuyerId);

                            buyerId = parsedBuyerId;

                            if (!isBuyerId)
                                continue;
                        }

                        Product product = new Product()
                        {
                            Name = productDTO.Name,
                            Price = price,
                            BuyerId = buyerId,
                            SellerId = sellerId
                        };

                        productsToImport.Add(product);

                    }
                }

               
                context.Products.AddRange(productsToImport);
                context.SaveChanges();
                result = $"Successfully imported {productsToImport.Count}";
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