namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static SocialNetwork.Common.SocialNetworkValidations.ConversationSocialNetworkValidations;

    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(conversationTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime StartedAt { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();

        public virtual ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();

    }
}
