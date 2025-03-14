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

            string filePath = @"..\..\..\Datasets\suppliers.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportSuppliers(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            string result = "";

            SupplierDTO[]? supplierDTOs = JsonConvert
                .DeserializeObject<SupplierDTO[]>(inputJson);

            if (supplierDTOs != null)
            {
                //using var transaction = context.Database.BeginTransaction();
                //try
                //{
                    ICollection<Supplier> suppliersToImport = new List<Supplier>();

                    foreach (var supDTO in supplierDTOs)
                    {
                        if (IsValid(supDTO))
                        {
                            bool isImorted = false;
                            if (supDTO.IsImporter == "true")
                                isImorted = true;

                            Supplier supplies = new Supplier()
                            {
                                Name = supDTO.Name,
                                IsImporter = isImorted
                            };

                            suppliersToImport.Add(supplies);
                        }

                    }

                    context.Suppliers.AddRange(suppliersToImport);
                    context.SaveChanges();

                    result =$"Successfully imported {suppliersToImport.Count}.";

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