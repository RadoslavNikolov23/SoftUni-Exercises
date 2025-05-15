namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Transactions;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbCcontext = new CarDealerContext();
            dbCcontext.Database.Migrate();

            string filePath = @"..\..\..\Datasets\parts.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportParts(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            string result = "";

            PartDTO[]? partsDTO = JsonConvert
                .DeserializeObject<PartDTO[]>(inputJson);

            if (partsDTO != null)
            {
                //using var transaction = context.Database.BeginTransaction();
                //try
                //{
                    ICollection<Part> partsToImport = new List<Part>();

                    int[] supplierIdsCollection = context.Suppliers
                        .Select(s => s.Id)
                        .ToArray();

                    foreach (var partDTO in partsDTO)
                    {
                        if (IsValid(partDTO))
                        {
                            decimal price = default;
                            int quantity = default;
                            int supplierId = default;

                            bool isPriced = decimal.TryParse(partDTO.Price, out decimal parsPrice);
                            bool isQuantity = int.TryParse(partDTO.Quantity, out int parsQuantity);
                            bool isupplierId = int.TryParse(partDTO.SupplierId, out int parsSuplierId);

                            if (isPriced && isQuantity && isupplierId)
                            {
                                price = parsPrice;
                                quantity = parsQuantity;
                                supplierId = parsSuplierId;

                                if (!supplierIdsCollection.Any(sId => sId == supplierId))
                                {
                                    continue;
                                }

                                Part part = new Part()
                                {
                                    Name = partDTO.Name,
                                    Price = price,
                                    Quantity = quantity,
                                    SupplierId = supplierId
                                };

                                partsToImport.Add(part);
                            }
                        }

                    }

                    context.Parts.AddRange(partsToImport);
                    context.SaveChanges();

                   // transaction.Commit();


                    result = $"Successfully imported {partsToImport.Count}.";

                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Something went wrong: ");
                //    Console.WriteLine(e.InnerException);
                //}

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