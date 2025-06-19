namespace DeskMarket.Common
{
    public static class Validation
    {
        public static class ProductValidation
        {
            public const int ProductNameMinLength = 2;
            public const int ProductNameMaxLength = 60;

            public const int ProductDescriptionMinLength = 10;
            public const int ProductDescriptionMaxLength = 250;

            public const decimal ProductPriceMinValue = 1.00m;
            public const decimal ProductPriceMaxValue = 3000.00m;

            public const string ProductPriceMinValueStr = "1.00";
            public const string ProductPriceMaxValueStr = "3000.00";

            public const int ProductDateLength = 10; // Length of "dd-MM-yyyy"
            public const string ProductDateFormat = "dd-MM-yyyy";
        }

        public static class CategoryValidation
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 20;
        }

    }
}
