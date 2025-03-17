namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTOs;
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

            string path = @"../../../Datasets/cars.xml";
            string inputXML = File.ReadAllText(path);

            string result = ImportCars(dbContex, inputXML);
            Console.WriteLine(result);

        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string result = "";

            ImportCarDTO[]? importCarDTOs = XmlHelper
                .Desirialize<ImportCarDTO[]>(inputXml, "Cars");

            if (importCarDTOs != null)
            {
                var partsId = context
                    .Parts
                    .Select(p => p.Id)
                    .ToArray();

                ICollection<Car> carsToAdd = new List<Car>();

                foreach (var carDTO in importCarDTOs)
                {
                    if (!IsValid(carDTO))
                        continue;

                    bool isTraveledDistance = long.TryParse(carDTO.TraveledDistance, out long traveledDistance);

                    if (!isTraveledDistance)
                        continue;

                    Car car = new Car()
                    {
                        Make = carDTO.Make,
                        Model = carDTO.Model,
                        TraveledDistance = traveledDistance
                    };

                    foreach (var idPart in carDTO.PartId!
                                            .Select(pId => int.Parse(pId.Id))
                                            .Distinct()
                                            .ToArray())
                    {
                        if (!partsId.Contains(idPart))
                            continue;

                        PartCar partCar = new PartCar()
                        {
                            PartId = idPart,
                            Car = car
                        };
                        car.PartsCars.Add(partCar);
                    }
                    carsToAdd.Add(car);
                }

                context.Cars.AddRange(carsToAdd);
                context.SaveChanges();
                result = @$"Successfully imported {carsToAdd.Count}";

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