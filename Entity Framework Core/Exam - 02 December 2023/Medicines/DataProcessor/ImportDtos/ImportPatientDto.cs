namespace Medicines.DataProcessor.ImportDtos
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using static Medicines.Common.MedicineValidation.PatientValidation;


    [JsonObject("Patient")]
    public class ImportPatientDto
    {
        [Required]
        [JsonProperty("FullName")]
        [MinLength(patientFullNameMinLength)]
        [MaxLength(patientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [JsonProperty("AgeGroup")]
        [Range(0, 2)]
        public int AgeGroup { get; set; }

        [Required]
        [JsonProperty("Gender")]
        [Range(0, 1)]
        public int Gender { get; set; }

        [Required]
        [JsonProperty("Medicines")]
        public int[] Medicines { get; set; } = null!;

    }
}
