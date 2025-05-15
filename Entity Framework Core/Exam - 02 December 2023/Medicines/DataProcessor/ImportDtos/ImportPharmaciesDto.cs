namespace Medicines.DataProcessor.ImportDtos
{
    using Medicines.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static Medicines.Common.MedicineValidation.MedicinePropertyValidation;
    using static Medicines.Common.MedicineValidation.PharmacyValidation;


    [XmlType("Pharmacy")]
    public class ImportPharmaciesDto
    {
        [Required]
        [XmlAttribute("non-stop")]
        public string Nonstop { get; set; } = null!; //boll

        [Required]
        [MinLength(pharmacyNameMinLength)]
        [MaxLength(pharmacyNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression(phoneNumberPattern)]
        [MinLength(phoneNumberLength)]
        [MaxLength(phoneNumberLength)]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Medicines")]
        public ImportMedicineByPharmacieDto[] Medicine { get; set; } = null!;
    }

    [XmlType("Medicine")]
    public class ImportMedicineByPharmacieDto
    {
        [Required]
        //[EnumDataType(typeof(Category))]
        [Range(0, 4)]
        [XmlAttribute("category")]
        public int Category { get; set; }

        [Required]
        [MinLength(medicineNameMinLength)]
        [MaxLength(medicineNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(medicinePriceMinValue, medicinePriceMaxValue)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; } = null!; //DateTime

        [Required]
        //[DataType(DataType.Date)]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; } = null!; //DateTime

        [Required]
        [MinLength(medicineProducerNameMinLength)]
        [MaxLength(medicineProducerNameMaxLength)]
        [XmlElement("Producer")]
        public string Producer { get; set; } = null!;
    }
}
