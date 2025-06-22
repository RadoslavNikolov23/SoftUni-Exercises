namespace RecipeSharingPlatform.ViewModels.CategoriesViewModel
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.GCommon.ValidationConstants.CategoryConstants;

    public class CategoryDetailViewMode
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
