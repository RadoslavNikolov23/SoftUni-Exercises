namespace ProductShop.DTOs.Import
{ 
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class ImportCategoryDTO
    {

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

    }
}
