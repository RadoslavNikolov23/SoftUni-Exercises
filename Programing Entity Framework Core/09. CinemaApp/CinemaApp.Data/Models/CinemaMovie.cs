namespace CinemaApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static ValidationConstants;

    public class CinemaMovie
    {
        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(Cinema))]
        public Guid CinemaId { get; set; }

        public Cinema Cinema { get; set; } = null!;

        [Comment("Tracks remaining tickets for the movie in a specific cinema")]
        public int? AvailableTickets { get; set; }


        [Comment("Shows if the movie in the cinema is Delete or Not")]
        public bool IsDeleted { get; set; }

        [Unicode(false)]
        [MaxLength(ValidationCinemaMovie.maxLengthShowtimesOfTheMoviesInTheCinema)]
        public string Showtimes { get; set; } = "00000";

    }
}