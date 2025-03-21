namespace CinemaApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants;

    public  class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(ValidationMovie.maxLengthMovieTitle)]
        [Comment("The title of the movie")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ValidationMovie.maxLengthGenre)]
        [Comment("The genre of the movie")]
        public string Genre { get; set; } = null!;

        [Required]
        [Comment("The realse date of the movie")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(ValidationMovie.maxLengthDirectorName)]
        [Comment("The name of the Director of the movie")]
        public string Director { get; set; } = null!;

        [Required]
        [Comment("Duration of the movie")]
        public int Duration { get; set; }

        [Required]
        [MaxLength(ValidationMovie.maxLengthDescriptionOfMovie)]
        [Comment("A small descrption of the movie")]
        public string Description { get; set; } = null!;

        [MaxLength(ValidationMovie.maxLengthImageUrlForMovie)]
        [Comment("Poster of the Movie")]
        public string? ImageUrl { get; set; }


        [Comment("Shows if the movie is Delete or Not")]
        public bool IsDeleted { get; set; }

        public ICollection<CinemaMovie> MovieCinemas  { get; set; } = new HashSet<CinemaMovie>();

        public ICollection<ApplicationUserMovie> MovieApplicationUsers { get; set; } = new HashSet<ApplicationUserMovie>();

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
