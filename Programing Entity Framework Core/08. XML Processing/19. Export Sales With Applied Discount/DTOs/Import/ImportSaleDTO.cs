namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Sale")]
    public class ImportSaleDTO
    {
        [Required]
        [XmlElement("discount")]
        public string Discount { get; set; } = null!;//decimal

        [Required]
        [XmlElement("carId")]
        public string CarId { get; set; } = null!; //int

        [Required]
        [XmlElement("customerId")]
        public string CustomerId { get; set; } = null!; //int
    }
}
