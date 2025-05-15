namespace TravelAgency.DataProcessor.ImportDtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using TravelAgency.Data.Models;
    using static Common.Validations.CustomerValidation;

    [XmlType("Customer")]
    public class CustomerDto
    {
        [Required]
        [XmlElement("FullName")]
        [MinLength(customerFullNameMinLength)]
        [MaxLength(customerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("Email")]
        [MinLength(customerEmailMinLength)]
        [MaxLength(customerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [XmlAttribute("phoneNumber")]
        [MaxLength(customerPhoneMaxLength)]
        [RegularExpression(customerPhoneRegularExpression)]
        public string PhoneNumber { get; set; } = null!;

    }
}
