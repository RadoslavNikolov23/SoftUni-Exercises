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
                .AsNoTracking()
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

        public async Task<DestinationDetailViewModel?> GetDestinationByIdAsync(int? destId, string userId)
        {
            DestinationDetailViewModel? destinationDetailVM = null;

            if (destId.HasValue)
            {
                Destination? destination = await this.dbContext.Destinations
                    .Include(d => d.Terrain)
                    .Include(d => d.Publisher)
                    .Include(d => d.UsersDestinations)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Id == destId && !d.IsDeleted);

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

        public async Task<DestinationEditViewModel?> GetDestinationForEditAsync(int? destId, string? userId)
        {
            DestinationEditViewModel? destinationEditVM = null;

            if (destId.HasValue)
            {
                Destination? destination = await this.dbContext
                    .Destinations
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

                if (destination != null &&
                    destination.PublisherId.ToLower() == userId!.ToLower())
                {
                    destinationEditVM = new DestinationEditViewModel
                    {
                        Id = destination.Id,
                        Name = destination.Name,
                        Description = destination.Description,
                        ImageUrl = destination.ImageUrl,
                        TerrainId = destination.TerrainId,
                        PublishedOn = destination.PublishedOn.ToString(DestinationConst.DateTimeFormat),
                        PublisherId = destination.PublisherId,
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
                && (destination != null) && (isDateParseable)
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

        public async Task<DestinationDeleteViewModel?> GetDestinationForDeleteAsync(int? destId, string userId)
        {
            DestinationDeleteViewModel? destinationDeleteVM = null;

            if (destId.HasValue)
            {
                Destination? destination = await this.dbContext
                    .Destinations
                    .Include(d => d.Publisher)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(d => d.Id == destId);

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

        public async Task<IEnumerable<DestinationFavoriteViewModel>> GetAllFavoriteDestinationsListAsync(string userId)
        {
            IEnumerable<DestinationFavoriteViewModel> favoriteDestinationsList = null!;

            IdentityUser? publisher = await this.userManager.FindByIdAsync(userId);

            if (publisher != null)
            {
                favoriteDestinationsList = await this.dbContext
                        .UsersDestinations
                        .Include(ud => ud.Destination)
                        .ThenInclude(d => d.Terrain)
                        .Where(ud => ud.UserId.ToLower() == userId!.ToLower())
                        .Select(ud => new DestinationFavoriteViewModel()
                        {
                            Id = ud.Destination.Id,
                            Name = ud.Destination.Name,
                            ImageUrl = ud.Destination.ImageUrl,
                            Terrain = ud.Destination.Terrain.Name,
                        })
                        .ToListAsync();
            }
            return favoriteDestinationsList;
        }

        public async Task<bool> AddToFavoriteListAsync(int destId, string userId)
        {
            bool isAdded = false;

            IdentityUser? publisher = await this.userManager.FindByIdAsync(userId);

            Destination? destination = await this.dbContext
                .Destinations
                .FindAsync(destId);

            if ((publisher != null)
                && (destination != null)
                && (destination.PublisherId.ToLower() != userId.ToLower()))
            {
                UserDestination? usersDestination = await this.dbContext
                        .UsersDestinations
                        .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId
                        && ud.DestinationId == destId);

                if (usersDestination == null)
                {
                    usersDestination = new UserDestination()
                    {
                        UserId = userId,
                        DestinationId = destId
                    };

                    await this.dbContext.UsersDestinations.AddAsync(usersDestination);
                    await this.dbContext.SaveChangesAsync();
                }
                isAdded = true;
            }
            return isAdded;
        }

        public async Task<bool> RemoveFavoriteFromListAsync(int destId, string userId)
        {
            bool isRemoved = false;

            IdentityUser? publisher = await this.userManager.FindByIdAsync(userId);

            Destination? destination = await this.dbContext
                .Destinations
                .FindAsync(destId);

            if ((publisher != null)
                && (destination != null)
                && (destination.PublisherId.ToLower() != userId.ToLower()))
            {
                UserDestination? usersDestination = await this.dbContext
                        .UsersDestinations
                        .SingleOrDefaultAsync(ud => ud.UserId.ToLower() == userId
                        && ud.DestinationId == destId);

                if (usersDestination != null)
                {
                    this.dbContext.UsersDestinations.Remove(usersDestination);
                    int result = await this.dbContext.SaveChangesAsync();
                    
                    isRemoved = true;
                }
            }
            return isRemoved;
        }
    }
}
