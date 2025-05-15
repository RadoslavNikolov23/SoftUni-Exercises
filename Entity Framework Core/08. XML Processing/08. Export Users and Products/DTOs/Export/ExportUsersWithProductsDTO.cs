namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class ExportUsersWithProductsDTO
    {
        [XmlElement("count")]
        public string Count { get; set; } = null!;

        [XmlArray("users")]
        public ExportUWPUsersDTO[] Users { get; set; } = null!;
    }

    [XmlType("User")]
    public class ExportUWPUsersDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!; 
        
        [XmlElement("age")]
        public string Age { get; set; } = null!;
        
        [XmlElement("SoldProducts")]
        public ExportUWPUSoldProductsDTO soldProducts { get; set; } = null!;


    }

    [XmlType("SoldProducts")]
    public class ExportUWPUSoldProductsDTO 
    {

        [XmlElement("count")]
        public string Count { get; set; } = null!;

        [XmlArray("products")]
        public ExportUWPUSPProductsDTO[]? Products { get; set; }
    }

    [XmlType("Product")]
    public class ExportUWPUSPProductsDTO
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public string Price { get; set; } = null!;
    }



}
