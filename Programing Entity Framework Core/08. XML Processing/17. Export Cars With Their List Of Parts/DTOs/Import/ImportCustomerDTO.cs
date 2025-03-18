namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomerDTO
    {

        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("birthDate")]
        public string BirthDate { get; set; } = null!;//DateTime

        [Required]
        [XmlElement("isYoungDriver")]
        public string IsYoungDriver { get; set; } = null!; //bool

    }
}
