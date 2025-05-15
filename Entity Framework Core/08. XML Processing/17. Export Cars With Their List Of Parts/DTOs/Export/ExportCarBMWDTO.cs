namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarBMWDTO
    {

        [XmlAttribute("id")]
        public string Id { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveled-distance")]
        public string TraveledDistance { get; set; } = null!;
    }
}
