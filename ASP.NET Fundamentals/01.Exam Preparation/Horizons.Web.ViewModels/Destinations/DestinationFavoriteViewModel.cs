namespace Horizons.Web.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants.TerrainConst;
   
    public class DestinationFavoriteViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public string Terrain { get; set; } = null!;

        public string? ImageUrl  { get; set; }
    }
}
