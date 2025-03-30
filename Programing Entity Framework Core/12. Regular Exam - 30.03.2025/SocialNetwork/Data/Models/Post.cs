namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SocialNetwork.Common.SocialNetworkValidations.PostSocialNetworkValidations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(postContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; } = null!;

    }
}