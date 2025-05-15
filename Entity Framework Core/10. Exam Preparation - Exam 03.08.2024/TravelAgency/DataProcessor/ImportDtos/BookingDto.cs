namespace TravelAgency.DataProcessor.ImportDtos
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class BookingDto
    {
        [Required]
        [JsonPropertyName("BookingDate")]
        public string BookingDate { get; set; } = "yyyy-MM-dd"; // default value


        [Required]
        [JsonPropertyName("CustomerName")]
        public string CustomerName { get; set; } = null!;


        [Required]
        [JsonPropertyName("TourPackageName")]
        public string TourPackageName { get; set; } = null!;
    }
}
