namespace BookShopDA.Model
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Validators.Validators;

    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [MaxLength(AuthorValidator.firstNameLength)]
        [Unicode]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(AuthorValidator.lastNameLength)]
        [Unicode]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
