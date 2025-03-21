namespace CinemaApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        [Comment("Ticket price for a movie")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Cinema))]
        public Guid CinemaId { get; set; }

        public Cinema Cinema { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}