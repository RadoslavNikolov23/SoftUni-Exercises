namespace Horizons.Web.ViewModels.Destinations
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants.DestinationConst;

    public class DestinationDeleteViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!; 
 
        public string PublisherId { get; set; } = null!;

        public string? Publisher { get; set; }
    }
}
