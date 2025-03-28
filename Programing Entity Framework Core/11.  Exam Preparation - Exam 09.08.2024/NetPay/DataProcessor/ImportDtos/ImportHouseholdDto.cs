namespace NetPay.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static NetPay.Common.ModelsValdiations.HouseholdValidations;

    [XmlType("Household")]
    public class ImportHouseholdDto
    {

        [Required]
        [MinLength(householdContactPersonMinLength)]
        [MaxLength(householdContactPersonMaxLength)]
        [XmlElement("ContactPerson")]
        public string ContactPerson { get; set; } = null!;

        [MinLength(householdEmailMinLength)]
        [MaxLength(householdEmailMaxLength)]
        [XmlElement("Email")]
        public string? Email { get; set; }

        [Required]
        [MaxLength(householdPhoneMaxLenth)]
        [RegularExpression(householdphoneNumberPattern)]
        [XmlAttribute("phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
