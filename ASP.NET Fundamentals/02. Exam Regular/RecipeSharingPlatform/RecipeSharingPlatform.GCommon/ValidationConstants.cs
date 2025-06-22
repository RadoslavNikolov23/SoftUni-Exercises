namespace RecipeSharingPlatform.GCommon
{
    public static class ValidationConstants
    {
        public static class RecipeConstants
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 80;

            public const int InstructionsMinLength = 10;
            public const int InstructionsMaxLength = 250;

            public const int RecipeDateLength = 10;
            public const string RecipeDateFormat = "dd-MM-yyyy";
        }

        public static class CategoryConstants
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;
        }
    }
}
