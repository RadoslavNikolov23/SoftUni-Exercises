namespace CinemaApp.Data.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class CinemaMoviesDTO
    {
        [Required]
        [JsonPropertyName("Movie")]
        public string Movie { get; set; } = null!;

        [Required]
        [JsonPropertyName("Cinema")]
        public string Cinema { get; set; } = null!;

        [JsonPropertyName("AvailableTickets")]
        public int AvailableTickets { get; set; }

        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Required]
        [JsonPropertyName("Showtimes")]
        public string Showtimes { get; set; } = null!;


    }
}
