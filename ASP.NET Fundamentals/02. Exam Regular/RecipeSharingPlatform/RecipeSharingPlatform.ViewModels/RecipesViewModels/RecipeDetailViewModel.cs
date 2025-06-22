namespace RecipeSharingPlatform.ViewModels.RecipesViewModels
{
    public class RecipeDetailViewModel : BaseRecipeViewModel
    {
        /* Just for information purpose:
        // public int Id { get; set; }

        // public string Title { get; set; } = null!;

        // public string? ImageUrl { get; set; }

        //The category name of the recipe
        //public string Category { get; set; } = null!;
        */

        public string Instructions { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Author { get; set; } = null!;

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}
