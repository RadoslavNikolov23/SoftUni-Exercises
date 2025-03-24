namespace CinemaApp.Data.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class MoviesDTO
    {
        [Required]
        [JsonPropertyName("Id")]
        public string Id { get; set; } = null!;

        [Required]
        [JsonPropertyName("Title")]
        public string Title { get; set; } = null!;

        [Required]
        [JsonPropertyName("Genre")]
        public string Genre { get; set; } = null!;

        [Required]
        [JsonPropertyName("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [JsonPropertyName("Director")]
        public string Director { get; set; } = null!;

        [Required]
        [JsonPropertyName("Duration")]
        public int Duration { get; set; }

        [Required]
        [JsonPropertyName("Description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("ImageUrl")]
        public string? ImageUrl { get; set; }


    }
}
