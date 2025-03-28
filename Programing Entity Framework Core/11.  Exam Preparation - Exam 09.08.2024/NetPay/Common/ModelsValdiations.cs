namespace NetPay.Common
{
    public static class ModelsValdiations
    {
        public static class HouseholdValidations
        {
            public const int householdContactPersonMinLength = 5;
            public const int householdContactPersonMaxLength = 50;


            public const int householdEmailMinLength = 6;
            public const int householdEmailMaxLength = 80;

            public const string householdPhoneNumberType = "char(15)";
            public const int householdPhoneMaxLenth = 15;
            public const string householdphoneNumberPattern = @"^\+\d{3}/\d{3}-\d{6}$";
        }

        public static class ExpenseValidations
        {
            public const int expenseNameMinLength = 5;
            public const int expenseNameMaxLength = 50;

            public const double expenseAmountMinValue = 0.01;
            public const double expenseAmountMaxValue = 100_000;
            public const string expenseAmountType = "decimal(18,2)";

            public const string expenseDueDateInputFormat = "yyyy-MM-dd";

            public const string expensePaymentStatusPaid = "Paid";
            public const string expensePaymentStatusUnpaid = "Unpaid";
            public const string expensePaymentStatusOverdue = "Overdue";
            public const string expensePaymentStatusExpired = "Expired";

        }

        public static class ServiceValidations
        {
            public const int serviceNameMinLength = 5;
            public const int serviceNameMaxLength = 30;
        }

        public static class SupplierValdiations
        {
            public const int supplierNameMinLength = 3;
            public const int supplierNameMaxLength = 60;
        }


    }
}
