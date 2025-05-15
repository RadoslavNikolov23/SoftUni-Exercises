namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserConversation
    {
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

        [Required]
        [ForeignKey("Conversation")]
        public int ConversationId { get; set; }

        public virtual Conversation Conversation { get; set; } = null!;

    }
}