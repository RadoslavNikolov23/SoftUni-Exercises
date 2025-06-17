namespace Horizons.Services.Core.Contracts
{
    using Horizons.Web.ViewModels.Destinations;

    public interface ITerrainService
    {
        Task<IEnumerable<DestinationAddTerrainViewModel>> GetAllTerrainsDropDownAsync();
    }
}
