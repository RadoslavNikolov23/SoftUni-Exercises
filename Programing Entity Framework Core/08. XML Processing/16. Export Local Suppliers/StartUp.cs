namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs.Export;
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

           // string path = @"../../../Datasets/sales.xml";
            //string inputXML = File.ReadAllText(path);

            string result = GetLocalSuppliers(dbContex);
            Console.WriteLine(result);

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {

            ExportLocalSupplierDTO[] localSupplierDTO = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDTO()
                {
                    Id = s.Id.ToString(),
                    Name=s.Name,
                    PartsCount=s.Parts.Count().ToString()
                })
                .ToArray();


            string result = XmlHelper.Serialize(localSupplierDTO, "suppliers");

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