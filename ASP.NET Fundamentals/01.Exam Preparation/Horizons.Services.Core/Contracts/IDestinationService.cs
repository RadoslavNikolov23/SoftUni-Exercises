namespace Horizons.Services.Core.Contracts
{
    using Horizons.Web.ViewModels.Destinations;

    public interface IDestinationService
    {
        Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string userId);
    }
}
