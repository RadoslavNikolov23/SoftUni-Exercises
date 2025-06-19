namespace DeskMarket.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static DeskMarket.Common.Validation.ProductValidation;


    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string Description { get; set; } = null!;


        [Range(typeof(decimal),ProductPriceMinValueStr, ProductPriceMaxValueStr)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public string SellerId { get; set; } = null!;

        public IdentityUser Seller { get; set; } = null!;

        public DateTime AddedOn { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();

    }
}
