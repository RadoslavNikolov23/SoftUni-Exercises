namespace Horizons.Web.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants.DestinationConst;

    public class DestinationDetailViewModel:BaseDestinationViewModel
    {
        public string Description { get; set; } = null!;

        public string PublishedOn { get; set; } = null!;

        public string Publisher { get; set; } = null!;


    }
}
