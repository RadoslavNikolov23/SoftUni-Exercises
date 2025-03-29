using Cadastre.Common;
using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
           var propertiosWithOwerns = dbContext
                .Properties
                .Where(p=>p.DateOfAcquisition.Year >= 2000 
                       && p.DateOfAcquisition.Month >= 01
                       && p.DateOfAcquisition.Day >= 01)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier=p.PropertyIdentifier,
                    Area = p.Area,
                    Address=p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy",
                                                            CultureInfo.InvariantCulture),
                    Owners = p.PropertiesCitizens
                            //.Where(pc => pc.Property.DateOfAcquisition.Year >= 2000
                            //         && pc.Property.DateOfAcquisition.Month >= 01
                            //         && pc.Property.DateOfAcquisition.Day >= 01)
                            .Select(pc=> new
                             {
                                LastName=pc.Citizen.LastName,
                                MaritalStatus=pc.Citizen.MaritalStatus.ToString(),
                            })
                            .OrderBy(pc => pc.LastName)
                            .ToArray()
                })
         
                .ToArray();

            var json = JsonConvert
                .SerializeObject(propertiosWithOwerns, Formatting.Indented);

            return json;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {

            var properties = dbContext
                .Properties
                .Where(p=>p.Area>=100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p=> new ExportPropertiesDto
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area.ToString(),
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy",
                                                            CultureInfo.InvariantCulture)
                })
                .ToArray();

            var results = XmlHelper.Serialize(properties, "Properties");

            return results;
        }
    }
}
