namespace Horizons.GCommon
{
    public static class ValidationConstants
    {
        public static class DestinationConst
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 80;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;

            public const string DateTimeFormat = "dd-MM-yyyy";
        }

        public static class TerrainConst
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }
    }
}
