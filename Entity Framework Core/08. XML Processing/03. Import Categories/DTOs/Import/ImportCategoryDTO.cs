namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ImportCategoryDTO
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

    }
}
