namespace RecipeSharingPlatform.ViewModels.RecipesViewModels
{
    public class RecipeEditViewModel : RecipeCreateViewModel
    {
        public int Id { get; set; }

        public string? AuthorId { get; set; }

    }
}
