namespace SocialNetwork.DataProcessor.ImportDTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static SocialNetwork.Common.SocialNetworkValidations.MessageSocialNetworkValidations;


    [XmlType("Message")]
    public class ImportMessagesDto
    {
        [Required]
        [XmlAttribute("SentAt")]
        public string SentAt { get; set; } = null!; //DateTime

        [Required]
        [XmlElement("Content")]
        [MinLength(messageContentMinLength)]
        [MaxLength(messageContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [XmlElement("Status")]
        public string Status { get; set; } = null!; //Status enum

        [Required]
        [XmlElement("ConversationId")]
        public string ConversationId { get; set; } = null!;

        [Required]
        [XmlElement("SenderId")]
        public string SenderId { get; set; } = null!;


    }
}
