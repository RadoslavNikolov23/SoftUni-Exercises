namespace BookShopDA.Model
{
    
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookCategory
    {
        [ForeignKey(nameof(Book))]
        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
