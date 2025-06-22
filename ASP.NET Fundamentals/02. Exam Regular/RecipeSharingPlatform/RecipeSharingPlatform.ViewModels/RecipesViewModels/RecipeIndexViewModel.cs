namespace RecipeSharingPlatform.ViewModels.RecipesViewModels
{
    public class RecipeIndexViewModel : BaseRecipeViewModel
    {
        /* Just for information purpose:
        //public int Id { get; set; }

        //public string Title { get; set; } = null!;

        //public string? ImageUrl { get; set; }

         //The category name of the recipe
        // public string Category { get; set; } = null!;
        */

        public int SavedCount { get; set; }

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }

    }
}
