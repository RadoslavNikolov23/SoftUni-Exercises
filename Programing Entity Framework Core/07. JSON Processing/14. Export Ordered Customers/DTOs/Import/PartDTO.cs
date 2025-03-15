namespace CarDealer.DTOs.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class PartDTO
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("price")]

        public string? Price { get; set; } //decimal

        [JsonPropertyName("quantity")]

        public string? Quantity { get; set; } //int

        [JsonPropertyName("supplierId")]

        public string? SupplierId { get; set; } //int
    }
}
