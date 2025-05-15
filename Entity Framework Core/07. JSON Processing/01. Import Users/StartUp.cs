namespace ProductShop
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbCcontext = new ProductShopContext();
            dbCcontext.Database.Migrate();

            string filePath = @"..\..\..\Datasets\users.json";
            string jsonFile = File.ReadAllText(filePath);

            string result = ImportUsers(dbCcontext, jsonFile);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDTO[]? importUserDTOs = JsonConvert
                .DeserializeObject<ImportUserDTO[]>(inputJson);

            ICollection<User> usersToImport = new List<User>();

            if (importUserDTOs != null)
            {
                foreach (ImportUserDTO userDTO in importUserDTOs)
                {
                    if (IsValid(userDTO))
                    {
                        int ageDTO = default;
                        if (userDTO.Age != null)
                        {
                            if (int.TryParse(userDTO.Age, out int age))
                                ageDTO = age;

                        }

                        User user = new User()
                        {
                            FirstName = userDTO.FirstName,
                            LastName = userDTO.LastName,
                            Age = ageDTO
                        };

                        usersToImport.Add(user);

                    }
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
                result = $"Successfully imported {usersToImport.Count}";
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