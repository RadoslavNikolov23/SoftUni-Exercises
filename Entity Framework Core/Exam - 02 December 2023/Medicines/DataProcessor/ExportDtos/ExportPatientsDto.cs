namespace Medicines.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("Patient")]
    public class ExportPatientsDto
    {
        [XmlAttribute("Gender")]
        public string Gender { get; set; } = null!;

        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("AgeGroup")]
        public string AgeGroup { get; set; } = null!;

        [XmlArray("Medicines")]
        public ExportMedicinesByPatientDto[] Medicines { get; set; } = null!;

    }

    [XmlType("Medicine")]
    public class ExportMedicinesByPatientDto
    {

        [XmlAttribute("Category")]
        public string Category { get; set; } = null!;

        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("Price")]
        public string Price { get; set; } = null!;

        [XmlElement("Producer")]
        public string Producer { get; set; } = null!;

        [XmlElement("BestBefore")]
        public string BestBefore { get; set; } = null!;

    }

}
