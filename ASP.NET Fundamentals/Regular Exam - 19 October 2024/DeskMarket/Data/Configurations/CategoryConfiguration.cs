namespace DeskMarket.Data.Configurations
{
    using DeskMarket.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static DeskMarket.Common.Validation.CategoryValidation;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> enitity)
        {
            enitity
                 .HasKey(c => c.Id);

            enitity
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CategoryNameMaxLength);

             enitity
                 .HasData(this.SeedCategories());
        }

        private ICollection<Category> SeedCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Laptops" },
                new Category { Id = 2, Name = "Workstations" },
                new Category { Id = 3, Name = "Accessories" },
                new Category { Id = 4, Name = "Desktops" },
                new Category { Id = 5, Name = "Monitors" }
            };

        }
    }
}
