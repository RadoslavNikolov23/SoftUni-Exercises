namespace Horizons.Services.Core.Contracts
{
    using Horizons.Web.ViewModels.Destinations;

    public interface IDestinationService
    {
        Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string? userId);

        Task<DestinationDetailViewModel?> GetDestinationByIdAsync(int? destId, string userId);

        Task<bool> AddDestinationAsync(DestinationAddViewModel destinationAddViewModel, string userId);

        Task<DestinationEditViewModel?> GetDestinationForEditAsync(int? destId, string? userId);

        Task<bool> EditDestinationAsync(DestinationEditViewModel destinationAddViewModel, string? userId);

        Task<DestinationDeleteViewModel?> GetDestinationForDeleteAsync(int? destId, string userId);

        Task<bool> SoftDeleteDestinationAsync(DestinationDeleteViewModel destinationDeleteViewModel, string userId);

        Task<IEnumerable<DestinationFavoriteViewModel>> GetAllFavoriteDestinationsListAsync(string userId);

        Task<bool> AddToFavoriteListAsync(int destId, string userId);

        Task<bool> RemoveFavoriteFromListAsync(int destId, string userId);


    }
}
