namespace RecipeSharingPlatform.ViewModels.RecipesViewModels
{
    using RecipeSharingPlatform.ViewModels.CategoriesViewModel;
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.GCommon.ValidationConstants.RecipeConstants;

    public class RecipeCreateViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(InstructionsMaxLength, MinimumLength = InstructionsMinLength)]
        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDetailViewMode>? Categories { get; set; }

        [Required]
        [StringLength(RecipeDateLength, MinimumLength = RecipeDateLength)]
        public string CreatedOn { get; set; } = null!;

    }
}
