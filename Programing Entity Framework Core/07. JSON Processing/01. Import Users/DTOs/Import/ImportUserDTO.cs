namespace ProductShop.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    public class ImportUserDTO
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = null!;

        [JsonPropertyName("age")]
        public string? Age { get; set; }
    }
}
