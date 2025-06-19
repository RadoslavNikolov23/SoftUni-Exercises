namespace DeskMarket.Services
{
    using DeskMarket.Data;
    using DeskMarket.Data.Models;
    using DeskMarket.Models.ProductViewModels;
    using DeskMarket.Services.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using static DeskMarket.Common.Validation.ProductValidation;

    public class ProductService : IProductService
    {
        private readonly DeskMarketDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public ProductService(DeskMarketDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync(string? userId)
        {
            IEnumerable<ProductIndexViewModel> allProducts = await this.dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.ProductsClients)
                .AsNoTracking()
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsSeller = String.IsNullOrEmpty(userId) == false ?
                                        p.SellerId.ToLower() == userId.ToLower()
                                        : false,
                    HasBought = String.IsNullOrEmpty(userId) == false ?
                                p.ProductsClients.Any(pc => pc.ClientId.ToLower() == userId.ToLower())
                                : false
                })
                .ToListAsync();

            return allProducts;
        }

        public async Task<bool> AddProductAsync(ProductAddViewModel inputProduct, string userId)
        {
            bool isAdded = false;

            IdentityUser? seller = await this.userManager
                                                    .FindByIdAsync(userId);

            Category? categoryRef = await this.dbContext
                            .Categories
                            .FindAsync(inputProduct.CategoryId);

            bool isDateParseable = DateTime.TryParseExact
                               (inputProduct.AddedOn,
                                ProductDateFormat,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime addedOnDate);

            if ((seller != null) && (categoryRef != null) && (isDateParseable))
            {
                Product newProduct = new Product
                {
                    ProductName = inputProduct.ProductName,
                    Description = inputProduct.Description,
                    Price = inputProduct.Price,
                    ImageUrl = inputProduct.ImageUrl,
                    SellerId = userId,
                    AddedOn= addedOnDate,
                    CategoryId = inputProduct.CategoryId,

                };

                await this.dbContext.Products.AddAsync(newProduct);
                await this.dbContext.SaveChangesAsync();
                isAdded = true;
            }

            return isAdded;

        }

        public async Task<ProductDetailsViewModel?> GetProductByIdAsync(int? productId, string userId)
        {

            ProductDetailsViewModel? productToDisplay = null;

            if (productId.HasValue)
            {
                Product? productToExtract = await this.dbContext
                    .Products
                    .Include(p => p.Category)
                    .Include(p => p.Seller)
                    .Include(p => p.ProductsClients)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.Id == productId);

                if (productToExtract != null)
                {
                    productToDisplay = new ProductDetailsViewModel
                    {
                        Id = productToExtract.Id,
                        ProductName = productToExtract.ProductName,
                        Description = productToExtract.Description,
                        Price = productToExtract.Price,
                        ImageUrl = productToExtract.ImageUrl,
                        CategoryName = productToExtract.Category.Name,
                        AddedOn = productToExtract.AddedOn.ToString(ProductDateFormat),
                        Seller = productToExtract.Seller.UserName!,
                        HasBought = String.IsNullOrEmpty(userId) == false ?
                                productToExtract.ProductsClients.Any(pc => pc.ClientId.ToLower() == userId.ToLower())
                                : false
                    };
                }
            }
            return productToDisplay;
        }

        public async Task<ProductEditViewModel?> GetProductForEditAsync(int? productId, string? userId)
        {
            ProductEditViewModel? productToEdit = null;

            if (productId.HasValue)
            {
                Product? productToFind = await this.dbContext
                    .Products
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p=> p.Id == productId);


                if (productToFind != null &&
                    productToFind.SellerId.ToLower() == userId!.ToLower())
                {
                    productToEdit = new ProductEditViewModel
                    {
                        Id = productToFind.Id,
                        ProductName = productToFind.ProductName,
                        Description = productToFind.Description,
                        Price= productToFind.Price,
                        ImageUrl = productToFind.ImageUrl,
                        AddedOn=productToFind.AddedOn.ToString(ProductDateFormat),
                        CategoryId = productToFind.CategoryId,
                        SellerId = productToFind.SellerId,
                    };
                }
            }

            return productToEdit;
        }

        public async Task<bool> EditProductAsync(ProductEditViewModel editedProduct, string? userId)
        {
            bool isEdited = false;

            IdentityUser? seller = await this.userManager.FindByIdAsync(userId);

            Category? categoryRev = await this.dbContext
                .Categories
                .FindAsync(editedProduct.CategoryId);

            Product? productToEdit = await this.dbContext
                .Products
                .FindAsync(editedProduct.Id);


            bool isDateParseable = DateTime.TryParseExact
                               (editedProduct.AddedOn,
                                ProductDateFormat,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime publishedOn);

            if ((seller != null) && (categoryRev != null)
                && (productToEdit != null) && (isDateParseable)
                && (productToEdit.SellerId.ToLower() == userId.ToLower()))
            {
                productToEdit.ProductName=editedProduct.ProductName;
                productToEdit.Description=editedProduct.Description;
                productToEdit.Price=editedProduct.Price;
                productToEdit.ImageUrl=editedProduct.ImageUrl;
                productToEdit.CategoryId=editedProduct.CategoryId;

                await this.dbContext.SaveChangesAsync();
                isEdited = true;

            }

            return isEdited;
        }

        public async Task<ProductDeleteViewModel?> GetProductForDeleteAsync(int? productId, string userId)
        {
            ProductDeleteViewModel productForDeletion = null;

            if (productId.HasValue)
            {
                Product? productToFind= await this.dbContext
                    .Products
                    .Include(p => p.Seller)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.Id == productId);

                if (productToFind != null &&
                    productToFind.SellerId.ToLower() == userId!.ToLower())
                {
                    productForDeletion = new ProductDeleteViewModel
                    {
                        Id = productToFind.Id,
                        ProductName = productToFind.ProductName,
                        SellerId = productToFind.SellerId,
                        Seller = productToFind.Seller.NormalizedUserName!,
                    };
                }
            }

            return productForDeletion;
        }

        public async Task<bool> SoftDeleteProductAsync(ProductDeleteViewModel productForDeletion, string userId)
        {
            bool isDeleted = false;

            IdentityUser? seller = await this.userManager.FindByIdAsync(userId);

            Product? productToDelete = await this.dbContext
                .Products
                .FindAsync(productForDeletion.Id);

            if ((seller != null)
                && (productToDelete != null)
                && (productToDelete.SellerId.ToLower() == userId.ToLower()))
            {
                productToDelete.IsDeleted = true;

                await this.dbContext.SaveChangesAsync();
                isDeleted = true;
            }

            return isDeleted;
        }

        public async Task<IEnumerable<ProductCartViewModel>> GetTheCartForProductsAsync(string userId)
        {
            IEnumerable<ProductCartViewModel> productCart = null!;

            IdentityUser? seller = await this.userManager
                                        .FindByIdAsync(userId);

            if (seller != null)
            {
                productCart = await this.dbContext
                        .ProductsClients
                        .Include(pc => pc.Product)
                        .ThenInclude(p => p.Category)
                        .Where(ud => ud.ClientId.ToLower() == userId!.ToLower())
                        .Select(ud => new ProductCartViewModel()
                        {
                            Id = ud.Product.Id,
                            ProductName = ud.Product.ProductName,
                            Price = ud.Product.Price,
                            ImageUrl = ud.Product.ImageUrl,

                        })
                        .ToListAsync();
            }
            return productCart;
        }

        public async Task<bool> AddToCartProductListAsync(int productId, string userId)
        {
            bool isAdded = false;

            IdentityUser? seller = await this.userManager.FindByIdAsync(userId);

            Product? product = await this.dbContext
                .Products
                .FindAsync(productId);

            if ((seller != null)
                && (product != null)
                && (product.SellerId.ToLower() != userId.ToLower()))
            {
                ProductClient? productClient = await this.dbContext
                        .ProductsClients
                        .SingleOrDefaultAsync(pc => pc.ClientId.ToLower() == userId.ToLower()
                        && pc.ProductId == productId);

                if (productClient == null)
                {
                    productClient = new ProductClient()
                    {
                        ProductId = productId,
                        ClientId = userId
                    };

                    await this.dbContext.ProductsClients.AddAsync(productClient);
                    await this.dbContext.SaveChangesAsync();
                }
                isAdded = true;
            }
            return isAdded;
        }

        public async Task<bool> RemoveFromCartProductAsync(int productId, string userId)
        {
            bool isRemoved = false;

            IdentityUser? seller = await this.userManager.FindByIdAsync(userId);

            Product? product = await this.dbContext
                            .Products
                            .FindAsync(productId);

            if ((seller != null)
                && (product != null)
                && (product.SellerId.ToLower() != userId.ToLower()))
            {
                ProductClient? productClient = await this.dbContext
                        .ProductsClients
                        .SingleOrDefaultAsync(pc => pc.ClientId.ToLower() == userId.ToLower()
                        && pc.ProductId == productId);

                if (productClient != null)
                {
                    this.dbContext.ProductsClients.Remove(productClient);
                    int result = await this.dbContext.SaveChangesAsync();

                    isRemoved = true;
                }
            }
            return isRemoved;
        }
    }
}
