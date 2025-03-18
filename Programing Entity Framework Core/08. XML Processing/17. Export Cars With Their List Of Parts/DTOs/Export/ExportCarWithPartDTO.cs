namespace CarDealer.DTOs.Export
{
    using CarDealer.Models;
    using System.Xml.Serialization;

    [XmlType("car")]

    public class ExportCarWithPartDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveled-distance")]
        public string TraveledDistance { get; set; } = null!;

        [XmlArray("parts")]
        public ExportCarWithPartDTOPartDTO[]? Parts { get; set; }
    }

    [XmlType("part")]
    public class ExportCarWithPartDTOPartDTO 
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("price")]
        public string Price { get; set; } = null!;
    }

}
