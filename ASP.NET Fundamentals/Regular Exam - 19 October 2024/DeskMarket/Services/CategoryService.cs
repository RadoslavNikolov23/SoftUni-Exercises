namespace DeskMarket.Services
{
    using DeskMarket.Data;
    using DeskMarket.Models.CategoriesViewModel;
    using DeskMarket.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly DeskMarketDbContext dbContext;

        public CategoryService(DeskMarketDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoriesIndexViewModel>> GetAllCategoriesDropDownAsync()
        {
            IList<CategoriesIndexViewModel> categories = await this.dbContext
                        .Categories
                        .AsNoTracking()
                        .Select(t => new CategoriesIndexViewModel
                        {
                            Id = t.Id,
                            Name = t.Name
                        })
                        .ToListAsync();

            return categories;
        }
    }
}
