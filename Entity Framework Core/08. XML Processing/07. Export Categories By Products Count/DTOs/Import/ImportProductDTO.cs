namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ImportProductDTO
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("price")]
        public string Price { get; set; } = null!;      //decimal

        [Required]
        [XmlElement("sellerId")]
        public string SellerId { get; set; } = null!;   //int

        //[Required]
        [XmlElement("buyerId")]
        public string? BuyerId { get; set; }    //int
    }
}
