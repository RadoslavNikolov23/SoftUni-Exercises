
namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class ImportCategoryProductDTO
    {
        [Required]
        [JsonPropertyName("CategoryId")]
        public string CategoryId { get; set; } = null!;

        [Required]
        [JsonPropertyName("ProductId")]
        public string ProductId { get; set; } = null!;
    }
}
