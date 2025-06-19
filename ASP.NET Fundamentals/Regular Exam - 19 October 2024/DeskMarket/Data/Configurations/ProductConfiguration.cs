namespace DeskMarket.Data.Configurations
{
    using DeskMarket.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static DeskMarket.Common.Validation.ProductValidation;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(ProductNameMaxLength);

            entity
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(ProductDescriptionMaxLength);

            entity
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            entity
                .Property(p => p.ImageUrl)
                .IsRequired(false);

            entity
                .Property(p => p.SellerId)
                .IsRequired();

            entity
                .HasOne(p => p.Seller)
                .WithMany()
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(p => p.AddedOn)
                .IsRequired();

            entity
                .Property(p => p.CategoryId)
                .IsRequired();

            entity
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(p => p.IsDeleted==false);

        }

    }
}
