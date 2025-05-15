namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static TravelAgency.Common.Validations.TourPackageValidation;

    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(packageNameMaxLength)]
        public string PackageName { get; set; } = null!;

        [MaxLength(descriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}