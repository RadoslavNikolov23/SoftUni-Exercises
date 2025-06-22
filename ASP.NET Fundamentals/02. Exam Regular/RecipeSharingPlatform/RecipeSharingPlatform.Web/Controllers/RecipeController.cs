namespace RecipeSharingPlatform.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Services.Core.Contracts;
    using RecipeSharingPlatform.ViewModels.RecipesViewModels;
    using static RecipeSharingPlatform.GCommon.ValidationConstants.RecipeConstants;

    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly ICategoryService categoryService;

        public RecipeController(IRecipeService recipeService, ICategoryService categoryService)
        {
            this.recipeService = recipeService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();

                IEnumerable<RecipeIndexViewModel> recipesCollection = await this.recipeService.GetAllRecipesAsync(userId);

                return this.View(recipesCollection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                RecipeDetailViewModel? recipeDetailVM = await this.recipeService.GetRecipeByIdAsync(id, userId);

                if (recipeDetailVM == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(recipeDetailVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                RecipeCreateViewModel recipeCreateVM = new RecipeCreateViewModel
                {
                    CreatedOn = DateTime.UtcNow.ToString(RecipeDateFormat),
                    Categories = await this.categoryService.GetAllCategoriesDropDownAsync()
                };

                return this.View(recipeCreateVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateViewModel recipeCreateVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    recipeCreateVM.CreatedOn = DateTime.UtcNow.ToString(RecipeDateFormat);
                    recipeCreateVM.Categories = await this.categoryService.GetAllCategoriesDropDownAsync();

                    return this.View(recipeCreateVM);
                }

                string userId = this.GetUserId()!;

                bool isAddedSuccessfully = await this.recipeService
                    .CreateRecipeAsync(recipeCreateVM, userId);

                if (!isAddedSuccessfully)
                {
                    this.ModelState.AddModelError(string.Empty, "Recipe could not be created. Please try again.");
                    return this.RedirectToAction(nameof(Create));

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
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                RecipeEditViewModel? recipeEditVM = await this.recipeService.GetRecipeForEditAsync(id, userId);

                if (recipeEditVM == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                recipeEditVM.Categories = await this.categoryService.GetAllCategoriesDropDownAsync();
                    

                return this.View(recipeEditVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel recipeEditVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");

                    recipeEditVM.CreatedOn = DateTime.UtcNow.ToString(RecipeDateFormat);
                    recipeEditVM.Categories = await this.categoryService.GetAllCategoriesDropDownAsync();

                    return this.View(recipeEditVM);
                }

                string userId = this.GetUserId()!;

                bool isRecipeEdited = await this.recipeService
                    .EditRecipeAsync(recipeEditVM, userId);

                if (isRecipeEdited == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Recipe could not be edited. Please try again.");
                    return this.View(recipeEditVM);
                }

                return this.RedirectToAction(nameof(Details), new { Id = recipeEditVM.Id });
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

                RecipeDeleteViewModel? recipeDeleteVM = await this.recipeService.GetRecipeForDeleteAsync(id, userId);

                if (recipeDeleteVM == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(recipeDeleteVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(RecipeDeleteViewModel recipeDeleteVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");
                    return this.View(recipeDeleteVM);
                }

                string userId = this.GetUserId()!;

                bool isRecipeDeleted = await this.recipeService
                                    .SoftDeleteRecipeAsync(recipeDeleteVM, userId);

                if (isRecipeDeleted == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Something went wrong, try again!");
                    return this.View(recipeDeleteVM);
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
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = this.GetUserId()!;

                IEnumerable<RecipeFavoriteViewMode> favoriteRecipeCollection = await this.recipeService.GetAllFavoriteRecipesCollectionAsync(userId);


                if (favoriteRecipeCollection == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favoriteRecipeCollection);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool isAddedToFavorite = await this.recipeService
                                      .AddToFavoriteRecipeCollectionAsync(id.Value, userId);


                if (isAddedToFavorite == false)
                {
                    // If the recipe was not added to favorites, we still redirect to the same page by default by the requirements.
                    return this.RedirectToAction(nameof(Index));
                }

                //As it says in the requirements, Upon successfully Adding a Recipe to the User's Favorites, should be redirected to /Recipe/Index
                return this.RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool isRemovedFromFavorite = await this.recipeService
                    .RemoveFavoriteRecipeCollectionAsync(id.Value, userId);

                if (isRemovedFromFavorite == false)
                {
                    // If the recipe was not removed from favorites, we still redirect to the same page by default by the requirements.
                    return this.RedirectToAction(nameof(Favorites));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
