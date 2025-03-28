using Newtonsoft.Json;
using System.Xml;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                .Where(g=>g.Language == Language.Spanish)
                .OrderByDescending(g=> g.TourPackagesGuides.Count)
                .ThenBy(g => g.FullName)
                .Select(g => new ExportGuideDto
                {
                    FullName = g.FullName,
                    TourPackagesGuides = g.TourPackagesGuides
                        .OrderByDescending(tpg => tpg.TourPackage.Price)
                        .ThenBy(tpg => tpg.TourPackage.PackageName)
                        .Select(tpg => new ExportTourPackageDto
                        {
                            PackageName = tpg.TourPackage.PackageName,
                            Description = tpg.TourPackage.Description,
                            Price = tpg.TourPackage.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray();

            var xml = XmlHelper.Serialize(guides, "Guides");

            return xml;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {

            var customers = context.Customers
                .Where(c=>c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new
                {
                    FullName=c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName=b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .OrderByDescending(c=>c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToArray();

            var json = JsonConvert
                .SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
    }
}
