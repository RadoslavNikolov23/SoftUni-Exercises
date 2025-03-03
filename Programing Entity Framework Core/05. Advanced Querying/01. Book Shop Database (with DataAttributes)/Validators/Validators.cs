namespace Validators
{
    public static class Validators
    {
        public static class AuthorValidator
        {
            public const int firstNameLength = 50;
            public const int lastNameLength = 50;
        }

        public static class BookValidator
        {
            public const int titleLength = 50;
            public const int descriptionLength = 1000;
        }

        public static class CategoryValidator
        {
            public const int nameLength = 50;
        }
    }
}
