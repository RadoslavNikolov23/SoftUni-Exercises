namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoriesByProductsCountDTO
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("count")]
        public string Count { get; set; } = null!;

        [XmlElement("averagePrice")]
        public string AveragePrice { get; set; } = null!;

        [XmlElement("totalRevenue")]
        public string TotalRevenue { get; set; } = null!;
    }
}
