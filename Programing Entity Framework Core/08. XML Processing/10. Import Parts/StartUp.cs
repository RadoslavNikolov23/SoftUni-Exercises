namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using CarDealer.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContex = new CarDealerContext();
            dbContex.Database.Migrate();
            Console.WriteLine("Database successfully been created....");

            string path = @"../../../Datasets/parts.xml";
            string inputXML = File.ReadAllText(path);

            string result = ImportParts(dbContex, inputXML);
            Console.WriteLine(result);

        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string result = "";

            ImportPartDTO[]? importPartDTOs = XmlHelper
                .Desirialize<ImportPartDTO[]>(inputXml, "Parts");

            if (importPartDTOs != null)
            {
                var suppliersId = context
                    .Suppliers
                    .Select(s => s.Id)
                    .ToArray();

                ICollection<Part> partsToAdd = new List<Part>();

                foreach(var partDTO in importPartDTOs)
                {
                    if (!IsValid(partDTO))
                        continue;

                    bool isPrice = decimal.TryParse(partDTO.Price, out decimal price);
                    bool isQuantity = int.TryParse(partDTO.Quantity, out int quantity);
                    bool isSupplierId = int.TryParse(partDTO.SupplierId, out int idSupplier);

                    if (!isPrice || !isQuantity || !isSupplierId)
                        continue;

                    if (!suppliersId.Any(sId => sId == idSupplier))
                        continue;

                    Part part = new Part()
                    {
                        Name = partDTO.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = idSupplier
                    };

                    partsToAdd.Add(part);
           
                }
                context.Parts.AddRange(partsToAdd);
                context.SaveChanges();
                result = @$"Successfully imported {partsToAdd.Count}";
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