namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.Validations.CustomerValidation;
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(customerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(customerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(customerPhoneMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
