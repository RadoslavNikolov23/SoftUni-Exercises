namespace CarDealer
{
    using CarDealer.Data;
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

            string path = @"../../../Datasets/sales.xml";
            string inputXML = File.ReadAllText(path);

            string result = ImportSales(dbContex, inputXML);
            Console.WriteLine(result);

        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string result = "";

            ImportSaleDTO[]? importSaleDTOs = XmlHelper
                .Desirialize<ImportSaleDTO[]>(inputXml, "Sales");

            if (importSaleDTOs != null)
            {
                var carIds = context
                    .Cars
                    .Select(c => c.Id)
                    .ToArray();

                ICollection<Sale> salesToAdd = new List<Sale>();

                foreach (var saleDTO in importSaleDTOs)
                {
                    if (!IsValid(saleDTO))
                        continue;

                    bool isDiscount = decimal.TryParse(saleDTO.Discount, out decimal discount);
                    bool isCarId = int.TryParse(saleDTO.CarId, out int idCar);
                    bool isCustomerId = int.TryParse(saleDTO.CustomerId, out int idCustomer);

                    if (!isDiscount || !isCarId || !isCustomerId)
                        continue;

                    if (!carIds.Contains(idCar))
                        continue;

                    Sale sale = new Sale()
                    {
                        Discount = discount,
                        CarId = idCar,
                        CustomerId = idCustomer
                    };

                    salesToAdd.Add(sale);

                }

                context.Sales.AddRange(salesToAdd);
                context.SaveChanges();
                result = @$"Successfully imported {salesToAdd.Count}";

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