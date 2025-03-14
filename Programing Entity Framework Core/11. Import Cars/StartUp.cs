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

            string filePath = @"..\..\..\Datasets\cars.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportCars(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }


        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            string result = "";
            CarDTO[]? carsDTO = JsonConvert
                 .DeserializeObject<CarDTO[]>(inputJson);

            if (carsDTO != null)
            {
                //using var transaction = context.Database.BeginTransaction();
                //try
                //{

                    foreach (var carDto in carsDTO)
                    {
                        long.TryParse(carDto.TraveledDistance, out long parseTravelDistance);
                        Car car = new Car
                        {
                            Make = carDto.Make,
                            Model = carDto.Model,
                            TraveledDistance = parseTravelDistance
                        };

                        context.Cars.Add(car);

                        foreach (var partId in carDto.PartsId.Select(p => int.TryParse(p, out int id) ? id : (int?)null)
                             .Where(pId => pId.HasValue)
                             .Select(pId => pId!.Value)
                             .ToArray())
                        {
                            PartCar partCar = new PartCar
                            {
                                CarId = car.Id,
                                PartId = partId
                            };

                            if (car.PartsCars.FirstOrDefault(p => p.PartId == partId) == null)
                            {
                                context.PartsCars.Add(partCar);
                            }
                        }
                    }

                    context.SaveChanges();
                   // transaction.Commit();


                    result = $"Successfully imported {carsDTO.Length}.";

                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Something went wrong: ");
                //    Console.WriteLine(e.InnerException.Message);
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