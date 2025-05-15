namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using ProductShop.Utilities;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();
            Console.WriteLine("Databse was created ......");

            string path = @"../../../Datasets/users.xml";
            string filePath = File.ReadAllText(path);

            string result = ImportUsers(dbContext, filePath);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string result = "";

            ImportUserDTO[]? userDTOs = XmlHelper
                .Desirialize<ImportUserDTO[]>(inputXml, "Users");

            if (userDTOs != null)
            {
                ICollection<User> usersToAdd = new List<User>();

                foreach (var userDTO in userDTOs)
                {
                    if (!IsValid(userDTO))
                        continue;

                    bool isAge = int.TryParse(userDTO.Age, out int age);

                    if (!isAge)
                        continue;

                    User user = new User()
                    {
                        FirstName = userDTO.FirstName,
                        LastName = userDTO.LastName,
                        Age = age
                    };
                    usersToAdd.Add(user);
                }

                context.Users.AddRange(usersToAdd);
                context.SaveChanges();
                result = $"Successfully imported {usersToAdd.Count}";

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