namespace RecipeSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RecipeSharingPlatform.Data.Models;
    using static RecipeSharingPlatform.GCommon.ValidationConstants.CategoryConstants;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity
                 .HasKey(c => c.Id);

            entity
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CategoryNameMaxLength);

            entity
               .HasData(this.SeedDefaultCategories());
        }

        private ICollection<Category> SeedDefaultCategories()
        {
            ICollection<Category> categoriesList = new List<Category>
            {
                new Category { Id = 1, Name = "Appetizer" },
                new Category { Id = 2, Name = "Main Dish" },
                new Category { Id = 3, Name = "Dessert" },
                new Category { Id = 4, Name = "Soup" },
                new Category { Id = 5, Name = "Salad" },
                new Category { Id = 6, Name = "Beverage" }
            };
            return categoriesList;
        }
    }
}
