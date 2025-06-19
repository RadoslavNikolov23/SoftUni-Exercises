namespace DeskMarket.Services.Contracts
{
    using DeskMarket.Models.ProductViewModels;

    public interface IProductService
    {
        Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync(string? userId);

        Task<bool> AddProductAsync(ProductAddViewModel inputProduct, string userId);

        Task<ProductDetailsViewModel?> GetProductByIdAsync(int? productId, string userId);

        Task<ProductEditViewModel?> GetProductForEditAsync(int? productId, string? userId);

        Task<bool> EditProductAsync(ProductEditViewModel editedProduct, string? userId);

        Task<ProductDeleteViewModel?> GetProductForDeleteAsync(int? productId, string userId);

        Task<bool> SoftDeleteProductAsync(ProductDeleteViewModel productForDeletion, string userId);

        Task<IEnumerable<ProductCartViewModel>> GetTheCartForProductsAsync(string userId);

        Task<bool> AddToCartProductListAsync(int productId, string userId);

        Task<bool> RemoveFromCartProductAsync(int productId, string userId);
    }
}
