namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TourPackageGuide
    {
        [ForeignKey(nameof(TourPackage))]
        public int TourPackageId { get; set; }

        public virtual TourPackage TourPackage { get; set; } = null!;

        [ForeignKey(nameof(Guide))]
        public int GuideId { get; set; }

        public virtual Guide Guide { get; set; } = null!;

    }
}