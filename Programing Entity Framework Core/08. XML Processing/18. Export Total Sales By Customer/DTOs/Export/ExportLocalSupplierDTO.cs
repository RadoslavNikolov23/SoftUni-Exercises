namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("supplier")]
    public class ExportLocalSupplierDTO
    {
        [XmlAttribute("id")]
        public string Id { get; set; } = null!;

        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("parts-count")]
        public string PartsCount { get; set; } = null!;
    }
}
