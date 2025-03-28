namespace TravelAgency.DataProcessor.ExportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Guide")]
    public class ExportGuideDto
    {
        [Required]
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [XmlArray("TourPackages")]
        public ExportTourPackageDto[]? TourPackagesGuides { get; set; }
    }

    [XmlType("TourPackage")]
    public class ExportTourPackageDto 
    {
        [Required]
        [XmlElement("Name")]
        public string PackageName { get; set; } = null!;

        [XmlElement("Description")]
        public string? Description { get; set; }

        [Required]
        [XmlElement("Price")]
        public string Price { get; set; } = null!;

    }
}
