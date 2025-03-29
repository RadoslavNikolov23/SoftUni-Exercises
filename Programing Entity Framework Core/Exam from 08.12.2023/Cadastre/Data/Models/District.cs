namespace Cadastre.Data.Models
{
    using Cadastre.Data.Enumerations;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Cadastre.Common.CadastreValidations.DistrictValidations;

    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(districtNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(postalCodeFormat)]
        public string PostalCode { get; set; } = null!;

        [Required]
        public Region Region { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();

 

    }
}
