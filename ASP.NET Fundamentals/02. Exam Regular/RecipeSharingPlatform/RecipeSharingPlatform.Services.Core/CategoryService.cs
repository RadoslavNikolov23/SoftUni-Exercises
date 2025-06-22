namespace RecipeSharingPlatform.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using RecipeSharingPlatform.Data;
    using RecipeSharingPlatform.Services.Core.Contracts;
    using RecipeSharingPlatform.ViewModels.CategoriesViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly RecipeSharingDbContext dbContext;

        public CategoryService(RecipeSharingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDetailViewMode>> GetAllCategoriesDropDownAsync()
        {
            List<CategoryDetailViewMode> terrains = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(t => new CategoryDetailViewMode
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return terrains;
        }
    }
}
