namespace Medicines.Data.Models
{
    using Medicines.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Medicines.Common.MedicineValidation.MedicinePropertyValidation;

    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(medicineNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = medicinePriceType)]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [MaxLength(medicineProducerNameMaxLength)]
        public string Producer { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyId { get; set; }

        public Pharmacy Pharmacy { get; set; } = null!;

        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
    }
}