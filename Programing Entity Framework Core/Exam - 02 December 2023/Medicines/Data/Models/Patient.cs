namespace Medicines.Data.Models
{
    using Medicines.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Medicines.Common.MedicineValidation.PatientValidation;


    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(patientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
    }
}