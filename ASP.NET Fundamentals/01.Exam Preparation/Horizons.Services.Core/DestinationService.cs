namespace Horizons.Services.Core
{
    using Horizons.Data;
    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destinations;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DestinationService : IDestinationService
    {
        private readonly HorizonsDbContext dbContext;

        public DestinationService(HorizonsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string userId)
        {
            //bool isGueid = !String.IsNullOrEmpty(userId) &&
           //                 Guid.TryParse(userId, out var parsedUserId);

            IEnumerable<DestinationViewModel> destinations = await this.dbContext.Destinations
                .Include(d => d.Terrain)
                .Include(d => d.UsersDestinations) // Assuming UsersDestinations is the navigation property for favorites
                .AsNoTracking() // Use AsNoTracking for read-only queries to improve performance
                .Where(d => !d.IsDeleted)
                .Select(d => new DestinationViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl,
                    Terrain = d.Terrain.Name,
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = String.IsNullOrEmpty(userId) == false ?
                            d.PublisherId.ToLower() == userId.ToLower() : false,
                    IsFavorite = String.IsNullOrEmpty(userId) == false ?
                            d.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false
                })
                .ToListAsync();

            return destinations;
        }
    }
}
