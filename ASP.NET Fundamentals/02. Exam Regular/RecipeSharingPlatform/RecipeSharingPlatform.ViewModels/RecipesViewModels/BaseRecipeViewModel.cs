namespace RecipeSharingPlatform.ViewModels.RecipesViewModels
{
    public abstract class BaseRecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? ImageUrl { get; set; }

        //The category name of the recipe
        public string Category { get; set; } = null!;

    }
}
