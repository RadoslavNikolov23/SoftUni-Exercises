namespace Horizons.Services.Core
{
    using Horizons.Data;
    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destinations;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TerrainService : ITerrainService
    {
        private readonly HorizonsDbContext dbContext;

        public TerrainService(HorizonsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DestinationAddTerrainViewModel>> GetAllTerrainsDropDownAsync()
        {
            List<DestinationAddTerrainViewModel> terrains = await this.dbContext.Terrains
                .AsNoTracking()
                .Select(t => new DestinationAddTerrainViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            return terrains;
        }
    }
}
