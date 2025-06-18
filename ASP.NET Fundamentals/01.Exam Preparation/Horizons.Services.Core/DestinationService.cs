namespace Horizons.Services.Core
{
    using Horizons.Data;
    using Horizons.Data.Models;
    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destinations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using static Horizons.GCommon.ValidationConstants;

    public class DestinationService : IDestinationService
    {
        private readonly HorizonsDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public DestinationService(HorizonsDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }


        public async Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string? userId)
        {
            //bool isGueid = !String.IsNullOrEmpty(userId) &&
            //                 Guid.TryParse(userId, out var parsedUserId);

            IEnumerable<DestinationViewModel> destinations = await this.dbContext.Destinations
                .Include(d => d.Terrain)
                 .Include(d => d.Publisher) 
                .Include(d => d.UsersDestinations) 
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

        public async Task<DestinationDetailViewModel?> GetDestinationByIdAsync(int? id, string? userId)
        {
            DestinationDetailViewModel? destinationDetailVM = null;

            if (id.HasValue)
            {
                Destination? destination = await this.dbContext.Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.Publisher)
                    .Include(d => d.UsersDestinations)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

                if (destination != null)
                {
                    destinationDetailVM = new DestinationDetailViewModel
                    {
                        Id = destination.Id,
                        Name = destination.Name,
                        Description = destination.Description,
                        ImageUrl = destination.ImageUrl,
                        Terrain = destination.Terrain.Name,
                        PublishedOn = destination.PublishedOn.ToString(DestinationConst.DateTimeFormat),
                        Publisher = destination.Publisher.UserName!,
                        IsPublisher = String.IsNullOrEmpty(userId) == false ?
                                destination.PublisherId.ToLower() == userId.ToLower() : false,
                        IsFavorite = String.IsNullOrEmpty(userId) == false ?
                                destination.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false
                    };
                }
            }

            return destinationDetailVM;
        }


        public async Task<bool> AddDestinationAsync(DestinationAddViewModel destinationAddViewModel, string userId)
        {
            bool isValid = false;
            IdentityUser? publisher = await this.userManager.FindByIdAsync(userId);

            Terrain? terrainRef = await this.dbContext
                .Terrains
                .FindAsync(destinationAddViewModel.TerrainId);

            bool isDateParseable = DateTime.TryParseExact                   
                               (destinationAddViewModel.PublishedOn, 
                                DestinationConst.DateTimeFormat,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None, 
                                out DateTime publishedOn);

            if ((publisher != null) && (terrainRef != null) && (isDateParseable))
            {
                Destination newDestination = new Destination
                {
                    Name = destinationAddViewModel.Name,
                    Description = destinationAddViewModel.Description,
                    ImageUrl = destinationAddViewModel.ImageUrl,
                    PublishedOn = publishedOn,
                    PublisherId = userId,
                    TerrainId = destinationAddViewModel.TerrainId,
                };

                await this.dbContext.Destinations.AddAsync(newDestination);
                await this.dbContext.SaveChangesAsync();
                isValid = true;
            }

            return isValid;
        }

        public async Task<DestinationEditViewModel?> GetDestinationForEditAsync(int? id, string? userId)
        {
            DestinationEditViewModel? destinationEditVM = null;

            if (id.HasValue)
            {
                Destination? destination = await this.dbContext
                    .Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

                if (destination != null &&
                    destination.PublisherId.ToLower()==userId!.ToLower())
                {
                    destinationEditVM = new DestinationEditViewModel
                    {
                        Id = destination.Id,
                        Name = destination.Name,
                        Description = destination.Description,
                        ImageUrl = destination.ImageUrl,
                        TerrainId = destination.TerrainId,
                        PublishedOn = destination.PublishedOn.ToString(DestinationConst.DateTimeFormat),
                        PublisherId = userId
                    };

                }
            }

            return destinationEditVM;
        }

        public async Task<bool> EditDestinationAsync(DestinationEditViewModel destinationEditViewModel, string? userId)
        {
            bool isValid = false;
            IdentityUser? publisher = await this.userManager.FindByIdAsync(userId);

            Terrain? terrainRef = await this.dbContext
                .Terrains
                .FindAsync(destinationEditViewModel.TerrainId);

            Destination? destination = await this.dbContext
                .Destinations
                .FindAsync(destinationEditViewModel.Id);

            bool isDateParseable = DateTime.TryParseExact
                               (destinationEditViewModel.PublishedOn,
                                DestinationConst.DateTimeFormat,
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out DateTime publishedOn);

            if ((publisher != null) && (terrainRef != null) 
                && (destination!=null) && (isDateParseable)
                && (destination.PublisherId.ToLower() == userId.ToLower()))
            {
                destination.Name = destinationEditViewModel.Name;
                destination.Description = destinationEditViewModel.Description;
                destination.PublishedOn = publishedOn;
                destination.ImageUrl = destinationEditViewModel.ImageUrl;
                destination.TerrainId = destinationEditViewModel.TerrainId;

                await this.dbContext.SaveChangesAsync();
                isValid = true;

            }

                return isValid;
        }

        public async Task<DestinationDeleteViewModel> GetDestinationForDeleteAsync(int? id, string userId)
        {
            DestinationDeleteViewModel? destinationDeleteVM = null;

            if (id.HasValue)
            {
                Destination? destination = await this.dbContext
                    .Destinations
                    //.Include(d => d.Terrain) //don't need to include the terrain here!
                    .Include(d => d.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

                if (destination != null &&
                    destination.PublisherId.ToLower() == userId!.ToLower())
                {
                    destinationDeleteVM = new DestinationDeleteViewModel
                    {
                        Id = destination.Id,
                        Name = destination.Name,
                        PublisherId = destination.PublisherId,
                        Publisher = destination.Publisher.NormalizedUserName
                    };

                }
            }

            return destinationDeleteVM;
        }

        public async Task<bool> SoftDeleteDestinationAsync(DestinationDeleteViewModel destinationDeleteViewModel, string userId)
        {
            bool isDeleted = false;
            IdentityUser? publisher = await this.userManager.FindByIdAsync(userId);


            Destination? destination = await this.dbContext
                .Destinations
                .FindAsync(destinationDeleteViewModel.Id);

  

            if ((publisher != null)
                && (destination != null)
                && (destination.PublisherId.ToLower() == userId.ToLower()))
            {
                destination.IsDeleted = true;

                await this.dbContext.SaveChangesAsync();
                isDeleted = true;

            }

            return isDeleted;
        }
    }
}
