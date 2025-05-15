namespace Medicines.DataProcessor
{
    using Medicines.Common;
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder resultSb = new StringBuilder();

            ImportPatientDto[]? importPatientDtos = JsonConvert
                .DeserializeObject<ImportPatientDto[]>(jsonString);

            if (importPatientDtos != null)
            {
                ICollection<Patient> patientsToAdd = new List<Patient>();

                foreach (var patientDto in importPatientDtos)
                {
                    if (!IsValid(patientDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Patient patient = new Patient()
                    {
                        FullName = patientDto.FullName,
                        AgeGroup = (AgeGroup)patientDto.AgeGroup,
                        Gender = (Gender)patientDto.Gender,
                    };

                    foreach (var medicineId in patientDto.Medicines)
                    {
                        if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        PatientMedicine patienMedicine = new PatientMedicine
                        {
                            Patient = patient,
                            MedicineId = medicineId
                        };

                        patient.PatientsMedicines.Add(patienMedicine);
                    }

                    patientsToAdd.Add(patient);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedPatient,
                        patient.FullName, patient.PatientsMedicines.Count));
                }

                context.Patients.AddRange(patientsToAdd);
                context.SaveChanges();

            }

            return resultSb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder resultSb = new StringBuilder();
            const string rootName = "Pharmacies";

            ImportPharmaciesDto[]? importPharmaciesDtos = XmlHelper
                .Desirialize<ImportPharmaciesDto[]>(xmlString, rootName);

            if (importPharmaciesDtos != null)
            {
                ICollection<Pharmacy> pharmaciesToAdd = new List<Pharmacy>();

                foreach (var pharcaiesDto in importPharmaciesDtos)
                {
                    if (!IsValid(pharcaiesDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isNonStopValid = bool.TryParse(pharcaiesDto.Nonstop, out bool isNonStop);

                    if (!isNonStopValid)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Pharmacy pharmacy = new Pharmacy
                    {
                        Name = pharcaiesDto.Name,
                        PhoneNumber = pharcaiesDto.PhoneNumber,
                        IsNonStop = isNonStop
                    };


                    foreach (var medicineDto in pharcaiesDto.Medicine)
                    {
                        if (!IsValid(medicineDto))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isProductionDateValid = DateTime
                                   .TryParseExact(medicineDto.ProductionDate,
                                                    "yyyy-MM-dd",
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                                                    out DateTime productionDate);

                        bool isExpireDateValid = DateTime
                                   .TryParseExact(medicineDto.ExpiryDate,
                                                    "yyyy-MM-dd",
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                                                    out DateTime expireDate);


                        if (!isProductionDateValid || !isExpireDateValid)
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (productionDate >= expireDate)
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (pharmacy.Medicines.Any(m => m.Name == medicineDto.Name
                             && m.Producer == medicineDto.Producer))
                        {
                            resultSb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Medicine medicine = new Medicine
                        {
                            Name = medicineDto.Name,
                            Price = medicineDto.Price,
                            Category = (Category)medicineDto.Category,
                            ExpiryDate = expireDate,
                            ProductionDate = productionDate,
                            Producer = medicineDto.Producer
                        };

                        pharmacy.Medicines.Add(medicine);
                    }

                    pharmaciesToAdd.Add(pharmacy);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
                }

                context.Pharmacies.AddRange(pharmaciesToAdd);
                context.SaveChanges();

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
