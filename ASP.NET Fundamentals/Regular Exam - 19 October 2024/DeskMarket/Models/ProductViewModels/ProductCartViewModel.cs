namespace DeskMarket.Models.ProductViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static DeskMarket.Common.Validation.ProductValidation;

    public class ProductCartViewModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]

        public string ProductName { get; set; } = null!;

        [Required]
        [Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
