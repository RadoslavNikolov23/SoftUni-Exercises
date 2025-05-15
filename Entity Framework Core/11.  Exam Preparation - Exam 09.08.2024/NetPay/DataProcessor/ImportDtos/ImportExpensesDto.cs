namespace NetPay.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using static NetPay.Common.ModelsValdiations.ExpenseValidations;

    public class ImportExpensesDto
    {
        [Required]
        [MaxLength(expenseNameMaxLength)]
        [MinLength(expenseNameMinLength)]
        [JsonPropertyName("ExpenseName")]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [Range(expenseAmountMinValue,expenseAmountMaxValue)]
        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("DueDate")]
        public string DueDate { get; set; } = null!;

        [Required]
        [JsonPropertyName("PaymentStatus")]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        [JsonPropertyName("HouseholdId")]
        public int HouseholdId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [JsonPropertyName("ServiceId")]
        public int ServiceId { get; set; }
    }
}
