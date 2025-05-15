namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ImportUserDTO
    {
        [Required]
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [XmlElement("age")]
        public string Age { get; set; } = null!; //int
    }
}
