namespace CarDealer.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSalesWithDiscountDTO
    {
        [XmlElement("car")]
        public ExportSalesWithDiscountCarDTO? CarDTO { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; } = null!;

        [XmlElement("customer-name")]
        public string CustomerName { get; set; } = null!;

        [XmlElement("price")]
        public string Price { get; set; } = null!;

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; } = null!;
    }

    [XmlType("car")]
    public class ExportSalesWithDiscountCarDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveled-distance")]
        public string TraveledDistance { get; set; } = null!;
    }

}
