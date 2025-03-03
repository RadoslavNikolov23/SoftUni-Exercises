namespace BookShopDA.Model
{
    using BookShopDA.Model.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Validators.Validators;

    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(BookValidator.titleLength)]
        [Unicode]
        public string Title { get; set; } = null!;


        [Required]
        [MaxLength(BookValidator.descriptionLength)]
        [Unicode]
        public string Descrtiption { get; set; } = null!;

        public DateTime? ReleaseDate  { get; set; }

        public int Copies  { get; set; }

        public decimal Price  { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        [Required]
        [ForeignKey(nameof(Authors))]
        public int AuthorId { get; set; }

        public virtual Author Authors { get; set; } = null!;

        public virtual ICollection<BookCategory> BookCategories { get; set; } = new HashSet<BookCategory>();
    }
}
