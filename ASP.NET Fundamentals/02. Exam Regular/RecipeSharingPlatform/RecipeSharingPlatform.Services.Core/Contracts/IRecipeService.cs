namespace RecipeSharingPlatform.Services.Core.Contracts
{
    using RecipeSharingPlatform.ViewModels.RecipesViewModels;

    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId);

        Task<RecipeDetailViewModel?> GetRecipeByIdAsync(int? recipeId, string? userId);

        Task<bool> CreateRecipeAsync(RecipeCreateViewModel recipeToCreate, string userId);

        Task<RecipeEditViewModel?> GetRecipeForEditAsync(int? recipeId, string? userId);

        Task<bool> EditRecipeAsync(RecipeEditViewModel recipeEditVM, string userId);

        Task<RecipeDeleteViewModel?> GetRecipeForDeleteAsync(int? recipeId, string userId);

        Task<bool> SoftDeleteRecipeAsync(RecipeDeleteViewModel recipeDeleteVM, string userId);

        Task<IEnumerable<RecipeFavoriteViewMode>> GetAllFavoriteRecipesCollectionAsync(string? userId);

        Task<bool> AddToFavoriteRecipeCollectionAsync(int recipeId, string userId);

        Task<bool> RemoveFavoriteRecipeCollectionAsync(int recipeId, string userId);

    }
}
