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

            string filePath = @"..\..\..\Datasets\sales.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportSales(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }


        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            string result = "";
            SalesDTO[]? salesDTOs = JsonConvert
                 .DeserializeObject<SalesDTO[]>(inputJson);

            if (salesDTOs != null)
            {
                //using var transaction = context.Database.BeginTransaction();
                //try
                //{
                    ICollection<Sale> salesToImport = new List<Sale>();

                    foreach (var salesDTO in salesDTOs)
                    {
                        if (IsValid(salesDTO))
                        {
                            decimal discount = default;
                            int carId = default;
                            int customerId = default;

                            bool isDiscount = decimal.TryParse(salesDTO.Discount, out decimal parseDiscount);
                            bool isCarId = int.TryParse(salesDTO.CarId, out int parseCarId);
                            bool isCutomerId = int.TryParse(salesDTO.CustomerId, out int parseCutomerId);

                            if (isDiscount && isCarId && isCutomerId)
                            {
                                discount = parseDiscount;
                                carId = parseCarId;
                                customerId = parseCutomerId;

                                Sale sale = new Sale()
                                {
                                    Discount = discount,
                                    CarId = carId,
                                    CustomerId = customerId
                                };

                                salesToImport.Add(sale);
                            }
                        }

                    }

                    context.Sales.AddRange(salesToImport);
                    context.SaveChanges();

                    //transaction.Commit();


                    result = $"Successfully imported {salesToImport.Count}.";

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