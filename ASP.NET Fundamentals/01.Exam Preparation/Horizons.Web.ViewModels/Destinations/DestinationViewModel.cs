namespace Horizons.Web.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants;

    public class DestinationViewModel: BaseDestinationViewModel
    {
        public int FavoritesCount { get; set; }

    }
}
