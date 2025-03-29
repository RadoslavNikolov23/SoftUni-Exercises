namespace Medicines.Common
{
    public static class MedicineValidation
    {
        public static class PharmacyValidation
        {
            public const int pharmacyNameMinLength = 2;
            public const int pharmacyNameMaxLength = 50;

            public const int phoneNumberLength = 14;
            public const string phoneNumberPattern = @"^\(\d{3}\) \d{3}-\d{4}$";
            public const string phoneNumberType = "char(14)";
        }

        public static class MedicinePropertyValidation
        {
            public const int medicineNameMinLength = 3;
            public const int medicineNameMaxLength = 150;

            public const double medicinePriceMinValue = 0.01;
            public const double medicinePriceMaxValue = 1000.00;
            public const string medicinePriceType = "decimal(18,2)";

            public const int medicineProducerNameMinLength = 3;
            public const int medicineProducerNameMaxLength = 100;
        }

        public static class PatientValidation
        {
            public const int patientFullNameMinLength = 5;
            public const int patientFullNameMaxLength = 100;
        }
    }
}
