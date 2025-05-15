namespace SocialNetwork.DataProcessor.ExportDTOs
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute("Friendships")]
        public string Friendships { get; set; } = null!; //int

        [XmlElement("Username")]
        public string Username { get; set; } = null!;

        [XmlArray("Posts")]
        public ExportPostDto[]? Posts { get; set; }

    }

    [XmlType("Post")]
    public class ExportPostDto
    {
        [XmlElement("Content")]
        public string Content { get; set; } = null!;


        [XmlElement("CreatedAt")]
        public string CreatedAt { get; set; } = null!;

    }
}
