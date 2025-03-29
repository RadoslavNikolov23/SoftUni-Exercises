namespace Cadastre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Cadastre.Common.CadastreValidations.PropertieValidations;

    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(propertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        public int Area { get; set; }

        [MaxLength(propertDetailsMaxLenght)]
        public string? Details { get; set; }

        [Required]
        [MaxLength(propertAddressMaxLenght)]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [Required]
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        public virtual District District { get; set; } = null!;

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();

    }
}