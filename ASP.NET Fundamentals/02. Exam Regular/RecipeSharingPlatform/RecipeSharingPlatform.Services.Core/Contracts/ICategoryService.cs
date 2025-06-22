namespace RecipeSharingPlatform.Services.Core.Contracts
{
    using RecipeSharingPlatform.ViewModels.CategoriesViewModel;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDetailViewMode>> GetAllCategoriesDropDownAsync();
    }
}
