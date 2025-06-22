namespace RecipeSharingPlatform.Services.Core
{
    using System.Globalization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using RecipeSharingPlatform.Data;
    using RecipeSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Services.Core.Contracts;
    using RecipeSharingPlatform.ViewModels.RecipesViewModels;
    using static RecipeSharingPlatform.GCommon.ValidationConstants.RecipeConstants;

    public class RecipeService : IRecipeService
    {
        private readonly RecipeSharingDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeService(RecipeSharingDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<RecipeIndexViewModel>> GetAllRecipesAsync(string? userId)
        {
            IEnumerable<RecipeIndexViewModel> recipesCollection = await this.dbContext
                .Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.UsersRecipes)
                .AsNoTracking()
                .Select(r => new RecipeIndexViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    ImageUrl = r.ImageUrl,
                    Category = r.Category.Name,
                    SavedCount = r.UsersRecipes.Count,
                    IsAuthor = String.IsNullOrEmpty(userId) == false ?
                            r.AuthorId.ToLower() == userId.ToLower() : false,
                    IsSaved = String.IsNullOrEmpty(userId) == false ?
                            r.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId.ToLower()) : false
                })
                .ToListAsync();

            return recipesCollection;
        }

        public async Task<RecipeDetailViewModel?> GetRecipeByIdAsync(int? recipeId, string? userId)
        {
            RecipeDetailViewModel? recipeDetailVM = null;

            if (recipeId.HasValue)
            {
                Recipe? recipeToExtract = await this.dbContext.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.UsersRecipes)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == recipeId);

                if (recipeToExtract != null)
                {
                    recipeDetailVM = new RecipeDetailViewModel
                    {
                        Id = recipeToExtract.Id,
                        Title = recipeToExtract.Title,
                        Instructions = recipeToExtract.Instructions,
                        ImageUrl = recipeToExtract.ImageUrl,
                        Category = recipeToExtract.Category.Name,
                        CreatedOn = recipeToExtract.CreatedOn.ToString(RecipeDateFormat),
                        Author = recipeToExtract.Author.UserName!,
                        IsAuthor = String.IsNullOrEmpty(userId) == false ?
                                recipeToExtract.AuthorId.ToLower() == userId.ToLower() : false,
                        IsSaved = String.IsNullOrEmpty(userId) == false ?
                                recipeToExtract.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId.ToLower()) : false
                    };
                }
            }

            return recipeDetailVM;
        }

        public async Task<bool> CreateRecipeAsync(RecipeCreateViewModel recipeToCreate, string userId)
        {
            bool isAdded = false;
            IdentityUser? author = await this.userManager
                                                    .FindByIdAsync(userId);

            Category? categoryRef = await this.dbContext
                .Categories
                .FindAsync(recipeToCreate.CategoryId);

            bool isDateParseable = DateTime.TryParseExact
                               (recipeToCreate.CreatedOn,
                                RecipeDateFormat,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime publishedOn);

            if ((author != null) && (categoryRef != null) && (isDateParseable))
            {
                Recipe newRecipe = new Recipe
                {
                    Title = recipeToCreate.Title,
                    Instructions = recipeToCreate.Instructions,
                    ImageUrl = recipeToCreate.ImageUrl,
                    CreatedOn = publishedOn,
                    AuthorId = userId,
                    CategoryId = recipeToCreate.CategoryId,
                };

                await this.dbContext.Recipes.AddAsync(newRecipe);
                await this.dbContext.SaveChangesAsync();
                isAdded = true;
            }

            return isAdded;
        }

        public async Task<RecipeEditViewModel?> GetRecipeForEditAsync(int? recipeId, string? userId)
        {
            RecipeEditViewModel? recipeEditVM = null;

            if (recipeId.HasValue && userId != null)
            {
                Recipe? recipeToEdit = await this.dbContext
                    .Recipes
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == recipeId);

                if (recipeToEdit != null &&
                    recipeToEdit.AuthorId.ToLower() == userId.ToLower())
                {
                    recipeEditVM = new RecipeEditViewModel
                    {
                        Id = recipeToEdit.Id,
                        Title = recipeToEdit.Title,
                        Instructions = recipeToEdit.Instructions,
                        ImageUrl = recipeToEdit.ImageUrl,
                        CategoryId = recipeToEdit.CategoryId,
                        CreatedOn= recipeToEdit.CreatedOn.ToString(RecipeDateFormat),
                        AuthorId = userId
                    };
                }
            }

            return recipeEditVM;
        }

        public async Task<bool> EditRecipeAsync(RecipeEditViewModel recipeEditVM, string userId)
        {
            bool isEdited = false;
            IdentityUser? author = await this.userManager
                                            .FindByIdAsync(userId);

            Category? categoryRef = await this.dbContext
                .Categories
                .FindAsync(recipeEditVM.CategoryId);

            Recipe? recipeToEdit = await FindRecipeByIdAsync(recipeEditVM.Id);


            bool isDateParseable = DateTime.TryParseExact
                               (recipeEditVM.CreatedOn,
                                RecipeDateFormat,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime publishedOn);

            if ((author != null) && (categoryRef != null)
                && (recipeToEdit != null) && (isDateParseable)
                && (recipeToEdit.AuthorId.ToLower() == userId.ToLower()))
            {
                recipeToEdit.Title = recipeEditVM.Title;
                recipeToEdit.Instructions = recipeEditVM.Instructions;
                recipeToEdit.ImageUrl = recipeEditVM.ImageUrl;
                recipeToEdit.CreatedOn = publishedOn;
                recipeToEdit.CategoryId = recipeEditVM.CategoryId;

                await this.dbContext.SaveChangesAsync();
                isEdited = true;
            }

            return isEdited;
        }

        public async Task<RecipeDeleteViewModel?> GetRecipeForDeleteAsync(int? recipeId, string userId)
        {
            RecipeDeleteViewModel? recipeDeleteVM = null;

            if (recipeId.HasValue)
            {
                Recipe? recipeToDelete = await this.dbContext
                    .Recipes
                    .Include(r => r.Author)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Id == recipeId);

                if (recipeToDelete != null &&
                    recipeToDelete.AuthorId.ToLower() == userId!.ToLower())
                {
                    recipeDeleteVM = new RecipeDeleteViewModel
                    {
                        Id = recipeToDelete.Id,
                        Title = recipeToDelete.Title,
                        AuthorId = userId,
                        Author = recipeToDelete.Author.UserName!
                    };
                }
            }

            return recipeDeleteVM;
        }

        public async Task<bool> SoftDeleteRecipeAsync(RecipeDeleteViewModel recipeDeleteVM, string userId)
        {
            bool isDeleted = false;

            IdentityUser? author = await this.userManager
                                                    .FindByIdAsync(userId);

            Recipe? recipeToDelete = await FindRecipeByIdAsync(recipeDeleteVM.Id);

            if ((author != null)
                && (recipeToDelete != null)
                && (recipeToDelete.AuthorId.ToLower() == userId.ToLower()))
            {
                recipeToDelete.IsDeleted = true;

                await this.dbContext.SaveChangesAsync();
                isDeleted = true;
            }

            return isDeleted;
        }

        public async Task<IEnumerable<RecipeFavoriteViewMode>> GetAllFavoriteRecipesCollectionAsync(string? userId)
        {
            IEnumerable<RecipeFavoriteViewMode> favoriteRecipeCollection = null!;

            if (string.IsNullOrEmpty(userId))
            {
                return favoriteRecipeCollection;
            }

            IdentityUser? author = await this.userManager.FindByIdAsync(userId);

            if (author != null)
            {
                favoriteRecipeCollection = await this.dbContext
                        .UsersRecipes
                        .Include(ur => ur.Recipe)
                        .ThenInclude(r => r.Category)
                        .Where(ur => ur.UserId.ToLower() == userId!.ToLower())
                        .Select(ur => new RecipeFavoriteViewMode()
                        {
                            Id = ur.Recipe.Id,
                            Title = ur.Recipe.Title,
                            ImageUrl = ur.Recipe.ImageUrl,
                            Category = ur.Recipe.Category.Name,
                        })
                        .ToListAsync();
            }

            return favoriteRecipeCollection;
        }

        public async Task<bool> AddToFavoriteRecipeCollectionAsync(int recipeId, string userId)
        {
            bool isAddedToFavorite = false;

            IdentityUser? author = await this.userManager.FindByIdAsync(userId);

            Recipe? recipe = await FindRecipeByIdAsync(recipeId);

            if ((author != null)
                && (recipe != null)
                && (recipe.AuthorId.ToLower() != userId.ToLower()))
            {
                UserRecipe? userRecipe = await this.dbContext
                        .UsersRecipes
                        .SingleOrDefaultAsync(ur => ur.UserId.ToLower() == userId
                        && ur.RecipeId == recipeId);

                if (userRecipe == null)
                {
                    userRecipe = new UserRecipe()
                    {
                        UserId = userId,
                        RecipeId = recipeId
                    };

                    await this.dbContext.UsersRecipes.AddAsync(userRecipe);
                    await this.dbContext.SaveChangesAsync();
                }
                isAddedToFavorite = true;
            }

            return isAddedToFavorite;
        }

        public async Task<bool> RemoveFavoriteRecipeCollectionAsync(int recipeId, string userId)
        {
            bool isRemovedFromFavorite = false;

            IdentityUser? author = await this.userManager.FindByIdAsync(userId);

            Recipe? recipe = await FindRecipeByIdAsync(recipeId);

            if ((author != null)
                && (recipe != null)
                && (recipe.AuthorId.ToLower() != userId.ToLower()))
            {
                UserRecipe? userRecipe = await this.dbContext
                        .UsersRecipes
                        .SingleOrDefaultAsync(ur => ur.UserId.ToLower() == userId
                        && ur.RecipeId == recipeId);

                if (userRecipe != null)
                {
                    this.dbContext.UsersRecipes.Remove(userRecipe);
                    int result = await this.dbContext.SaveChangesAsync();

                    isRemovedFromFavorite = true;
                }
            }

            return isRemovedFromFavorite;
        }

        private async Task<Recipe?> FindRecipeByIdAsync(int recipeId)
        {
            return await this.dbContext
                    .Recipes
                    .FindAsync(recipeId);
        }
    }
}
