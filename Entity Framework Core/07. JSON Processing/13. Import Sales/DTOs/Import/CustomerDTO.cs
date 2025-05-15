

namespace CarDealer.DTOs.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    public class CustomerDTO
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("birthDate")]
        public string? BirthDate { get; set; } //DateTime

        [JsonPropertyName("isYoungDriver")]
        public string? IsYoungDriver { get; set; } //bool
    }
}
