using CinemaApp.Data.Validations;

namespace CinemaApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants;


    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ValidationCinema.maxLengthCinemaName)]
        [Comment("The name of the Cinema")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationCinema.maxLengthNameOfTheLocationOfCinema)]
        [Comment("The location of the Cinema")]
        public string Location { get; set; } = null!;

        [Comment("Shows if a cinema is Delete or Not")]
        public bool IsDeleted { get; set; }

        public ICollection<CinemaMovie> CinemaMovies { get; set; } = new HashSet<CinemaMovie>();

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();


    }
}
