namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs;
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

            string path = @"../../../Datasets/suppliers.xml";
            string inputXML = File.ReadAllText(path);

            string result = ImportSuppliers(dbContex, inputXML);
            Console.WriteLine(result);

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string result = "";

            ImportSupplierDTO[]? supplierDTOs = XmlHelper
                .Desirialize<ImportSupplierDTO[]>(inputXml, "Suppliers");

            if (supplierDTOs != null)
            {
                ICollection<Supplier> suppliersToAdd = new List<Supplier>();

                foreach(var supDTO in supplierDTOs)
                {
                    if (!IsValid(supDTO))
                    {
                        continue;
                    }

                    bool isImportedBool = bool.TryParse(supDTO.IsImporter, out bool isImported);

                    if (!isImportedBool)
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = supDTO.Name,
                        IsImporter = isImported
                    };

                    suppliersToAdd.Add(supplier);
                }

                context.Suppliers.AddRange(suppliersToAdd);
                context.SaveChanges();
                result = @$"Successfully imported {suppliersToAdd.Count}";
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