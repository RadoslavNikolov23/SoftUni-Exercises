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

            string result = GetCarsWithDistance(dbContex);
            Console.WriteLine(result);

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {

            ExportCarWithDistnaceDTO[] carWithDistanceDTO = context
                .Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new ExportCarWithDistnaceDTO()
                {
                    Make=c.Make,
                    Model=c.Model,
                    TraveledDistance=c.TraveledDistance.ToString()
                })
                .OrderBy(c=>c.Make)
                .ThenBy(c=>c.Model)
                .Take(10)
                .ToArray();

            string result = XmlHelper.Serialize(carWithDistanceDTO, "cars");

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