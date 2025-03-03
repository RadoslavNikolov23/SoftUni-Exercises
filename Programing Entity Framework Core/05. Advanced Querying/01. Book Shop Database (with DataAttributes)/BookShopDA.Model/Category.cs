namespace BookShopDA.Model
{
    
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Validators.Validators;

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(CategoryValidator.nameLength)]
        [Unicode]
        public string Name { get; set; } = null!;

        public virtual ICollection<BookCategory> CategoryBooks { get; set; } = new HashSet<BookCategory>();
    }
}
