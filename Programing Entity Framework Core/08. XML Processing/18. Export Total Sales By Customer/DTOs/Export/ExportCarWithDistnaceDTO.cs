namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithDistnaceDTO
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [XmlElement("traveled-distance")]
        public string TraveledDistance { get; set; } = null!;
    }
}
