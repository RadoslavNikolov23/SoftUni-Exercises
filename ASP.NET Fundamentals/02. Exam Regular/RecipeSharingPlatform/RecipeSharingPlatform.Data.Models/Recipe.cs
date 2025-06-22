namespace RecipeSharingPlatform.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string AuthorId { get; set; } = null!;

        public IdentityUser Author { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public ICollection<UserRecipe> UsersRecipes { get; set; } = new HashSet<UserRecipe>();
    }
}
