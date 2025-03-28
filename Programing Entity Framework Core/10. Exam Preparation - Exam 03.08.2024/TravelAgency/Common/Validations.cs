namespace TravelAgency.Common
{
    public static class Validations
    {
        public static class CustomerValidation
        {
            public const int customerFullNameMinLength = 4;

            public const int customerFullNameMaxLength = 60;

            public const int customerEmailMinLength = 6;

            public const int customerEmailMaxLength = 50;

            public const int customerPhoneMaxLength = 13;

            public const string customerPhoneRegularExpression = @"\+[0-9]{12}";


        }

        public static class BookingValidation
        {
            public const string bookingDateFormat = "yyyy-MM-dd";
        }
        public static class GuideValidation
        {
            public const int guideFullNameMinLength = 4;

            public const int guideFullNameMaxLength = 60;

        }

        public static class TourPackageValidation
        {
            public const int packageNameMinLength = 2;

            public const int packageNameMaxLength = 40;

            public const int descriptionMaxLength = 200;

            public const double tourPackageMinPrice = 0.1;

            public const double tourPackageMaxPrice = 1000000;
        }
    }
}
