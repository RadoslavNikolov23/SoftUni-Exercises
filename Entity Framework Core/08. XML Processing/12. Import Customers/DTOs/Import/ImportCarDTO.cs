namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCarDTO
    {
        [Required]
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [Required]
        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [Required]
        [XmlElement("traveledDistance")]
        public string TraveledDistance { get; set; } = null!; // long

        [XmlArray("parts")]
        public ImportPartCarDTO[]? PartId { get; set; }

    }
}
