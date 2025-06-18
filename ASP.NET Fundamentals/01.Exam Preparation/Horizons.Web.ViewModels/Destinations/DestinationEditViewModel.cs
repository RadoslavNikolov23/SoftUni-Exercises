namespace Horizons.Web.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;

    public class DestinationEditViewModel : DestinationAddViewModel
    {
        [Required]
        public int Id { get; set; } // This should be the ID of the destination being edited

        [Required]
        public string PublisherId { get; set; } = null!;
    }
}
