namespace CinemaApp.Data.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class TicketDto
    {
        [Required]
        [XmlElement("Price")]
        public string Price { get; set; } = null!;

        [Required]
        [XmlElement("CinemaId")]
        public string CinemaId { get; set; } = null!;

        [Required]
        [XmlElement("MovieId")]
        public string MovieId { get; set; } = null!;

        [Required]
        [XmlElement("UserId")]
        public string UserId { get; set; } = null!;

    }
}
