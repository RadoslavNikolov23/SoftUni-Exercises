namespace Cadastre.Common
{
    public static class CadastreValidations
    {
        public static class DistrictValidations
        {
            public const int districtNameMinLength = 2;
            public const int districtNameMaxLength = 80;

            public const int postalCodeLength = 8;
            public const string postalCodeFormat = "char(8)";
            public const string postalCodeRegix = @"^[A-Z]{2}\-\d{5}$";

        }

        public static class PropertieValidations
        {

            public const int propertyIdentifierMinLength = 16;
            public const int propertyIdentifierMaxLength = 20;

            public const int propertDetailsMinLenght = 5;
            public const int propertDetailsMaxLenght = 500;

            public const int propertAddressMinLenght = 5;
            public const int propertAddressMaxLenght = 200;
        }

    
        public static class CitizenValidations
        {
            public const int citizenFirstNameMinLength = 2;
            public const int citizenFirstNameMaxLength = 30;

            public const int citizenLastNameMinLength = 2;
            public const int citizenLastNameMaxLength = 30;
        }
    }
}
