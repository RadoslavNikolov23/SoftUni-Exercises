namespace CarDealer.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSupplierDTO
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("isImporter")]
        public string IsImporter { get; set; } = null!; //it's original bool
    }
}
