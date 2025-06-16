namespace Horizons.Web.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants;

    public class DestinationViewModel
    {
        public int Id { get; set; }

        [MinLength(DestinationConst.NameMinLength)]
        [MaxLength(DestinationConst.NameMaxLength)]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        //Terrain Name is used here
        [MinLength(TerrainConst.NameMinLength)]
        [MaxLength(TerrainConst.NameMaxLength)]
        public string Terrain { get; set; } = null!;

        public int FavoritesCount { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }

    }
}
