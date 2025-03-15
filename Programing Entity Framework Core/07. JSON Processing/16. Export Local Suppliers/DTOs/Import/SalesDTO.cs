namespace CarDealer.DTOs.Import
{
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    public class SalesDTO
    {

        [JsonPropertyName("discount")]
        public string? Discount { get; set; } //decimal

        [JsonPropertyName("carId")]

        public string? CarId { get; set; } //int

        [JsonPropertyName("customerId")]

        public string? CustomerId { get; set; } //int
    }
}
