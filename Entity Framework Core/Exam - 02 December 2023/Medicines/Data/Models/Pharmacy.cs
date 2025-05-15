namespace Medicines.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Medicines.Common.MedicineValidation.PharmacyValidation;

    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(pharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = phoneNumberType)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public bool IsNonStop { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();


    }
}
