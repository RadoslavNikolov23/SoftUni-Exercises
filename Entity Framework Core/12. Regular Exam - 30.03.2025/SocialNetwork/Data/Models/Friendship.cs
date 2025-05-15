namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        [Required]
        [ForeignKey("UserOne")]
        public int UserOneId { get; set; }

        public User UserOne { get; set; } = null!;

        [Required]
        [ForeignKey("UserTwo")]
        public int UserTwoId { get; set; }

        public User UserTwo { get; set; } = null!;

    }
}
