namespace Cadastre.DataProcessor
{
    using Cadastre.Common;
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder resultSb = new StringBuilder();
            const string rootElement = "Districts";

            ImportDistrictsDto[]? importDistrictsDtos = XmlHelper
                .Desirialize<ImportDistrictsDto[]>(xmlDocument, rootElement);

            if (importDistrictsDtos != null)
            {
                ICollection<District> districsToAdd = new List<District>();

                foreach (var importedDistrict in importDistrictsDtos)
                {
                    if (!IsValid(importedDistrict))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Districts.Any(d => d.Name == importedDistrict.Name))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isRegionValid = Enum.TryParse<Region>(importedDistrict.Region, out Region region);

                    if (!isRegionValid)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    District district = new District
                    {
                        Name = importedDistrict.Name,
                        PostalCode = importedDistrict.PostalCode,
                        Region = region
                    };


                    foreach (var propertyDto in importedDistrict.Properties)
                    {
                        if (!IsValid(propertyDto))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier) || district.Properties.Any(dp => dp.PropertyIdentifier == propertyDto.PropertyIdentifier))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }
                        if (dbContext.Properties.Any(p => p.Address == propertyDto.Address) || district.Properties.Any(dp => dp.Address == propertyDto.Address))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isDateofAcquistitionValid = DateTime
                            .TryParseExact(propertyDto.DateOfAcquisition,
                                            "dd/MM/yyyy",
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None
                                            , out DateTime dateOfAcquistion);

                        if (!isDateofAcquistitionValid)
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }
                        Property property = new Property
                        {
                            PropertyIdentifier = propertyDto.PropertyIdentifier,
                            Area = propertyDto.Area,
                            Details = propertyDto.Details,
                            Address = propertyDto.Address,
                            DateOfAcquisition = dateOfAcquistion
                        };
                        district.Properties.Add(property);
                    }

                    districsToAdd.Add(district);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
                }

                dbContext.Districts.AddRange(districsToAdd);
                dbContext.SaveChanges();
            }

            return resultSb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder resultSb = new StringBuilder();

            ImportCitizensDto[]? importCitizensDtos = JsonConvert
                .DeserializeObject<ImportCitizensDto[]>(jsonDocument);

            if (importCitizensDtos != null)
            {
                ICollection<Citizen> citizensToAdd = new List<Citizen>();

                foreach (var importedCitizen in importCitizensDtos)
                {
                    if (!IsValid(importedCitizen))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isBirthDateValid = DateTime
                        .TryParseExact(importedCitizen.BirthDate,
                                        "dd-MM-yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out DateTime birthDate);

                    bool isMaritalStatusValid = Enum
                        .TryParse<MaritalStatus>(importedCitizen.MaritalStatus,
                                                out MaritalStatus maritalStatus);

                    if (!isBirthDateValid || !isMaritalStatusValid)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Citizen citizen = new Citizen
                    {
                        FirstName = importedCitizen.FirstName,
                        LastName = importedCitizen.LastName,
                        BirthDate = birthDate,
                        MaritalStatus = maritalStatus

                    };

                    foreach (var propertyDto in importedCitizen.Properties)
                    {
                        if (!IsValid(propertyDto))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        PropertyCitizen propertyCitizen = new PropertyCitizen
                        {
                            PropertyId = propertyDto,
                            Citizen = citizen
                        };

                        citizen.PropertiesCitizens.Add(propertyCitizen);
                    }
                    citizensToAdd.Add(citizen);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
                }
                dbContext.Citizens.AddRange(citizensToAdd);
                dbContext.SaveChanges();
            }

            return resultSb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
