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

            string result = GetTotalSalesByCustomer(dbContex);
            Console.WriteLine(result);

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            ExportCustomsDTO[] customsDTOs = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars=c.Sales.Count,
                    SpentMoney=c.Sales.Select( s=> new
                                        {
                                            Price= c.IsYoungDriver?
                                                s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95,2))
                                                :
                                                 s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                                        })
                                        .ToArray()      
                })
                .ToArray()
                .OrderByDescending(s=>s.SpentMoney.Sum(s=>s.Price))
                .Select(s => new ExportCustomsDTO()
                {
                    FullName = s.FullName,
                    BoughtCars = s.BoughtCars.ToString(),
                    SpentMoney = Math.Round((decimal)s.SpentMoney.Sum(y => y.Price), 2).ToString()
                })
                .ToArray();

            string result = XmlHelper.Serialize(customsDTOs, "customers");

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