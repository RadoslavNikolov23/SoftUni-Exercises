namespace SocialNetwork.DataProcessor.ImportDTOs
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using static SocialNetwork.Common.SocialNetworkValidations.PostSocialNetworkValidations;

    public class ImportPostDto
    {
        [Required]
        [JsonPropertyName("Content")]
        [MinLength(postContentMinLength)]
        [MaxLength(postContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [JsonPropertyName("CreatedAt")]
        public string CreatedAt { get; set; } = null!;

        [Required]
        public string CreatorId { get; set; } = null!;

    }
}
