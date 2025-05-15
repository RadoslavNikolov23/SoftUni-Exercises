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

            string result = GetCarsWithTheirListOfParts(dbContex);
            Console.WriteLine(result);

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            ExportCarWithPartDTO[] carWithPartDTO = context
                 .Cars
                 .OrderByDescending(c => c.TraveledDistance)
                 .ThenBy(c => c.Model)
                 .Take(5)
                 .Select(c => new ExportCarWithPartDTO()
                 {
                     Make = c.Make,
                     Model = c.Model,
                     TraveledDistance = c.TraveledDistance.ToString(),
                     Parts = c.PartsCars
                            .OrderByDescending(pc => pc.Part.Price)
                            .Select(pc => new ExportCarWithPartDTOPartDTO()
                            {
                                Name = pc.Part.Name,
                                Price = pc.Part.Price.ToString()
                            })
                            .ToArray()
                 })
                 .ToArray();



            string result = XmlHelper.Serialize(carWithPartDTO, "cars");

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