namespace CinemaApp.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserMovie
    {
        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; } = null!;

    }
}