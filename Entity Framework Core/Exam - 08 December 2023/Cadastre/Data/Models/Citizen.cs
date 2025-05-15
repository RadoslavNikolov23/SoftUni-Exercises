namespace Cadastre.Data.Models
{
    using Cadastre.Data.Enumerations;
    using System.ComponentModel.DataAnnotations;
    using static Cadastre.Common.CadastreValidations.CitizenValidations;

    public class Citizen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(citizenFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(citizenLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();

    }
}