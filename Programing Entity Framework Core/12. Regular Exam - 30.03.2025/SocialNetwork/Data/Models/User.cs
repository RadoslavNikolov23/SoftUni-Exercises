namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static SocialNetwork.Common.SocialNetworkValidations.UserSocialNetworkValidations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(userUserNameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(userEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public virtual ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();

    }
}
