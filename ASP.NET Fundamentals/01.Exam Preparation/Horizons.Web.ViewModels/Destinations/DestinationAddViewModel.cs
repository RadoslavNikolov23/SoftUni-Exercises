namespace Horizons.Web.ViewModels.Destinations
{
    using Horizons.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants;

    public class DestinationAddViewModel
    {
        [Required]
        [MinLength(DestinationConst.NameMinLength)]
        [MaxLength(DestinationConst.NameMaxLength)]
        public string Name { get; set; } = null!;

        public int TerrainId { get; set; }

        public IEnumerable<DestinationAddTerrainViewModel> Terrains { get; set; } = null!;

        [Required]
        [MinLength(DestinationConst.DescriptionMinLength)]
        [MaxLength(DestinationConst.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [MinLength(DestinationConst.PublishedOnLength)]
        [MaxLength(DestinationConst.PublishedOnLength)]
        public string PublishedOn { get; set; } = null!;

    }
}
