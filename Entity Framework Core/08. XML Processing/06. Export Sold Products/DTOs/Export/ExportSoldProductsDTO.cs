namespace ProductShop.DTOs.Export
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportSoldProductsDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("soldProducts")]
        public virtual ExportedSoldProductsNamesDTO[]? ProductsSold { get; set; }
    }

    [XmlType("Product")]
    public class ExportedSoldProductsNamesDTO
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public string Price { get; set; } = null!;
    }
}
