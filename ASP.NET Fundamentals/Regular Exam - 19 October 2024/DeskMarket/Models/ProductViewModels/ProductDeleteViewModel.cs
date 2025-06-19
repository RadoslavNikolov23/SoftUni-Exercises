namespace DeskMarket.Models.ProductViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static DeskMarket.Common.Validation.ProductValidation;

    public class ProductDeleteViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]

        public string ProductName { get; set; } = null!;

        [Required]
        public string SellerId { get; set; } = null!;

        public string? Seller { get; set; }

    }
}
