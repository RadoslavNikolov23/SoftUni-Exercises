namespace DeskMarket.Services.Contracts
{
    using DeskMarket.Models.CategoriesViewModel;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoriesIndexViewModel>> GetAllCategoriesDropDownAsync();
    }
}
