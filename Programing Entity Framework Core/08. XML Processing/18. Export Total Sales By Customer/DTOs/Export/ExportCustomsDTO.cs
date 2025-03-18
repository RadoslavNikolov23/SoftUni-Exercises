namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class ExportCustomsDTO
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public string BoughtCars { get; set; } = null!;//DateTime

        [XmlAttribute("spent-money")]
        public string SpentMoney { get; set; } = null!; //bool
    }
}
