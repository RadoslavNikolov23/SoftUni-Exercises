namespace NetPay.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static NetPay.Common.ModelsValdiations.HouseholdValidations;

    public class Household
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(householdContactPersonMaxLength)]
        public string ContactPerson { get; set; } = null!;

        [MaxLength(householdEmailMaxLength)]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = householdPhoneNumberType)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();

    }
}
