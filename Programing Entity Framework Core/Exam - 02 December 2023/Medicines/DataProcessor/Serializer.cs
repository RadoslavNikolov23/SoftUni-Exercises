namespace Medicines.DataProcessor
{
    using Medicines.Common;
    using Medicines.Data;
    using Medicines.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            bool isDateValid = DateTime.TryParse(date,out DateTime giveDate);

            if (!isDateValid)
            {
                throw new ArgumentException("Invalid date format!");

            }

            var patientsWithMedicines = context
                .Patients
                .Where(p => p.PatientsMedicines.Any(pm=>pm.Medicine.ProductionDate > giveDate))
                .Select(p => new ExportPatientsDto
                {
                    Gender=p.Gender.ToString().ToLower(),
                    Name=p.FullName,
                    AgeGroup=p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                                    .Where(pm=> pm.Medicine.ProductionDate > giveDate)
                                    .OrderByDescending(m=>m.Medicine.ExpiryDate)
                                    .ThenBy(m=>m.Medicine.Price)
                                    .Select(m=> new ExportMedicinesByPatientDto
                                    {
                                        Category=m.Medicine.Category.ToString().ToLower(),
                                        Name=m.Medicine.Name,
                                        Price=m.Medicine.Price.ToString("F2"),
                                        Producer=m.Medicine.Producer,
                                        BestBefore=m.Medicine.ExpiryDate.ToString("yyyy-MM-dd")
                                    })
                                    .ToArray()
                })
                .OrderByDescending(pm => pm.Medicines.Length)
                .ThenBy(pm => pm.Name)
                .ToArray();

            var result = XmlHelper
                .Serialize(patientsWithMedicines, "Patients");

            return result;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => (int)m.Category == medicineCategory
                        && m.Pharmacy.IsNonStop == true)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("f2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber,
                    }
                })

                .ToArray();

            var result = JsonConvert
                .SerializeObject(medicines, Formatting.Indented);

            return result.ToString();
        }
    }
}
