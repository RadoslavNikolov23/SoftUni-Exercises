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

            string result = GetSalesWithAppliedDiscount(dbContex);
            Console.WriteLine(result);

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesWithDiscountDTO[] salesWithDiscountDTOs = context
                .Sales
                .Select(s => new ExportSalesWithDiscountDTO()
                {
                    Discount=((int)s.Discount).ToString(),
                    CustomerName=s.Customer.Name,
                    Price= s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("F2").TrimEnd('0').TrimEnd('.'),
                    PriceWithDiscount= (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100))).ToString("F4").TrimEnd('0').TrimEnd('.'),
                    CarDTO=new ExportSalesWithDiscountCarDTO()
                    {
                        Make=s.Car.Make,
                        Model=s.Car.Model,
                        TraveledDistance=s.Car.TraveledDistance.ToString()
                    }
                })
                .ToArray();
           
            string result = XmlHelper.Serialize(salesWithDiscountDTOs,"sales");

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