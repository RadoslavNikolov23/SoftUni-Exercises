namespace DeskMarket.Models.ProductViewModels
{
    using DeskMarket.Models.CategoriesViewModel;
    using System.ComponentModel.DataAnnotations;
    using static DeskMarket.Common.Validation.ProductValidation;


    public class ProductEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]

        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(ProductDateLength, MinimumLength = ProductDateLength)]
        public string AddedOn { get; set; } = null!;

        //Check if this is required or not
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoriesIndexViewModel>? Categories { get; set; }

        [Required]
        public string SellerId { get; set; } = null!;
    }
}
