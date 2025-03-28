namespace NetPay.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("Household")]
    public class ExportHouseholdsDto
    {
        [XmlElement("ContactPerson")]
        public string ContactPerson { get; set; } = null!;

        [XmlElement("Email")]
        public string? Email { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Expenses")]
        public ExportExpenseHouseholdDto[] Expenses { get; set; } = null!;
    }

    [XmlType("Expense")]
    public class ExportExpenseHouseholdDto 
    {
        [XmlElement("ExpenseName")]
        public string ExpenseName { get; set; } = null!;

        [XmlElement("Amount")]
        public string Amount { get; set; } = null!;

        [XmlElement("PaymentDate")]
        public string PaymentDate { get; set; } = "yyyy-MM-dd";

        [XmlElement("ServiceName")]
        public string ServiceName { get; set; } = null!;

    }
}
