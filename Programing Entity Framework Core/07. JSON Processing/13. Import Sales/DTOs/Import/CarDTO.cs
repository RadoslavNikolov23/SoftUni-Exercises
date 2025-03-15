namespace CarDealer.DTOs.Import
{
    using CarDealer.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    class CarDTO
    {
        [Required]
        [JsonPropertyName("make")]
        public string Make { get; set; } = null!;

        [JsonPropertyName("model")]
        public string Model { get; set; } = null!;
        
        [JsonPropertyName("traveledDistance")]
        public string? TraveledDistance { get; set; } //long

        [JsonPropertyName("partsId")]
        public List<string> PartsId { get; set; } = new List<string>(); //int[]

    }
}
