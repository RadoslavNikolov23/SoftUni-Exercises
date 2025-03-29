namespace Cadastre.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("Property")]
    public class ExportPropertiesDto
    {
        [XmlAttribute("postal-code")]
        public string PostalCode { get; set; } = null!;

        [XmlElement("PropertyIdentifier")]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement("Area")]
        public string Area { get; set; } = null!;

        [XmlElement("DateOfAcquisition")]
        public string DateOfAcquisition { get; set; } = null!;

    }
}
