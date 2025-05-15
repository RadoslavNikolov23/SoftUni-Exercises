namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class SupplierDTO
    {

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("isImporter")]
        public string? IsImporter { get; set; }

    }
}
