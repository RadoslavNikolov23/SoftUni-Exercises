namespace DeskMarket.Data.Configurations
{
    using DeskMarket.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> entity)
        {
            entity
                .HasKey(pc => new { pc.ProductId, pc.ClientId });

            entity
                .HasQueryFilter(pc => pc.Product.IsDeleted == false);

            entity
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(pc => pc.ProductId);

            entity
                .HasOne(pc => pc.Client)
                .WithMany()
                .HasForeignKey(pc => pc.ClientId);
        }

    }


}
