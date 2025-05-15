namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    public class ImportProductDTO
    {
        [Required]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonPropertyName("Price")]
        public string Price { get; set; } = null!; // is decimal value

        [Required]
        [JsonPropertyName("SellerId")]
        public string SellerId { get; set; } = null!; // is int value

        [JsonPropertyName("BuyerId")]
        public string? BuyerId { get; set; } // is int value

    }
}
