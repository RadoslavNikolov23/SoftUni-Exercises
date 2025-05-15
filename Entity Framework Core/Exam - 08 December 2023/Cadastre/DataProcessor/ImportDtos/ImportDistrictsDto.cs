namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static Cadastre.Common.CadastreValidations.DistrictValidations;
    using static Cadastre.Common.CadastreValidations.PropertieValidations;


    [XmlType(nameof(District))]
    public class ImportDistrictsDto
    {
        [Required]
        [MinLength(districtNameMinLength)]
        [MaxLength(districtNameMaxLength)]
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(postalCodeLength)]
        [RegularExpression(postalCodeRegix)]
        [XmlElement(nameof(PostalCode))]
        public string PostalCode { get; set; } = null!;

        [Required]
        [XmlAttribute(nameof(Region))]
        public string Region { get; set; } = null!;

        [XmlArray(nameof(Properties))]
        [XmlArrayItem(nameof(Property))]
        public ImportDistrickPropertiesDto[] Properties { get; set; } = null!;
    }

    [XmlType(nameof(Property))]
    public class ImportDistrickPropertiesDto
    {
        [Required]
        [MinLength(propertyIdentifierMinLength)]
        [MaxLength(propertyIdentifierMaxLength)]
        [XmlElement(nameof(PropertyIdentifier))]
        public string PropertyIdentifier { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        [XmlElement(nameof(Area))]
        public int Area { get; set; }

        [MinLength(propertDetailsMinLenght)]
        [MaxLength(propertDetailsMaxLenght)]
        [XmlElement(nameof(Details))]
        public string? Details { get; set; }

        [Required]
        [MinLength(propertAddressMinLenght)]
        [MaxLength(propertAddressMaxLenght)]
        [XmlElement(nameof(Address))]
        public string Address { get; set; } = null!;

        [Required]
        [XmlElement(nameof(DateOfAcquisition))]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
