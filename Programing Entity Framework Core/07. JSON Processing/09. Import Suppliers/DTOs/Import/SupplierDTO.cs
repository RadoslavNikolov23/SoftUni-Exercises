namespace CarDealer.DTOs.Import
{
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class SupplierDTO
    {

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("isImporter")]
        public string? IsImporter { get; set; }

    }
}
