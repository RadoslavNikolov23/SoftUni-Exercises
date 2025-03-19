namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDTO
    {
        [Required]
        [XmlElement("CategoryId")]
        public string CategoryId { get; set; } = null!;//int

        [Required]
        [XmlElement("ProductId")]
        public string ProductId { get; set; } = null!; //int
    }
}
