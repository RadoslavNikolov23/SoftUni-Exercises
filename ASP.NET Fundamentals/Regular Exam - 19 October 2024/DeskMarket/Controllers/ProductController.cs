namespace DeskMarket.Controllers
{
    using DeskMarket.Models.ProductViewModels;
    using DeskMarket.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();

                IEnumerable<ProductIndexViewModel> allProducts = 
                                await this.productService.GetAllProductsAsync(userId);

                return this.View(allProducts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                ProductAddViewModel productsToAdd = new ProductAddViewModel
                {
                    Categories = await this.categoryService.GetAllCategoriesDropDownAsync()
                };

                return this.View(productsToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel productToAdd)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction(nameof(Add));
                }

                string userId = this.GetUserId()!;

                bool isAddedSuccessfully = await this.productService
                    .AddProductAsync(productToAdd, userId);

                if (!isAddedSuccessfully)
                {
                    this.ModelState.AddModelError(string.Empty, "Product could not be added. Please try again.");
                    return this.RedirectToAction(nameof(Add));

                }
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                ProductDetailsViewModel? productToDisplay = await this.productService.GetProductByIdAsync(id, userId);

                if (productToDisplay == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(productToDisplay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                ProductEditViewModel? productToEdit = await this.productService
                                                    .GetProductForEditAsync(id, userId);

                if (productToEdit == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                productToEdit.Categories = await this.categoryService.GetAllCategoriesDropDownAsync();

                return this.View(productToEdit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel productToEdit)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction(nameof(Edit), new { id = productToEdit.Id });
                }

                string? userId = this.GetUserId();

                bool isProductEdit = await this.productService
                    .EditProductAsync(productToEdit, userId);;

                if (isProductEdit == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Product could not be edited. Please try again.");
                    return this.View(productToEdit);
                }

                return this.RedirectToAction(nameof(Details), new { Id = productToEdit.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                ProductDeleteViewModel? productToDelete = await this.productService.GetProductForDeleteAsync(id, userId);

                if (productToDelete == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(productToDelete);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteViewModel productToDelete)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Please do not modify this product!");
                    return this.View(productToDelete);
                }

                string userId = this.GetUserId()!;

                bool isProductDeleted = await this.productService
                    .SoftDeleteProductAsync(productToDelete, userId);

                if (isProductDeleted == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred. Please try again.");
                    return this.View(productToDelete);
                }

                return this.RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                string userId = this.GetUserId()!;

                IEnumerable<ProductCartViewModel> productCartList = await this.productService
                    .GetTheCartForProductsAsync(userId);

                if (productCartList == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(productCartList);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool isAddedToCart = await this.productService
                    .AddToCartProductListAsync(id.Value, userId);

                if (isAddedToCart == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Cart));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool isRemovedFromCart = await this.productService
                    .RemoveFromCartProductAsync(id.Value, userId);


                if (isRemovedFromCart == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Cart));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
