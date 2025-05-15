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

            string result = GetCarsFromMakeBmw(dbContex);
            Console.WriteLine(result);

        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarBMWDTO[] carBMWDTO = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportCarBMWDTO()
                {
                    Id=c.Id.ToString(),
                    Model=c.Model,
                    TraveledDistance=c.TraveledDistance.ToString()
                })
                .ToArray();
            

            string result = XmlHelper.Serialize(carBMWDTO,"cars");

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