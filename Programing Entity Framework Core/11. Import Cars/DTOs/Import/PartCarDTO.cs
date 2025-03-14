namespace CarDealer.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;

    public class PartCarDTO
    {
        [Required]
        public string? PartId { get; set; } //int

        [Required]
        public string? CarId { get; set; } //int
    }
}
