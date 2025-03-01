using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Username { get; set; } = null!; 

       
        [MaxLength(250)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;


        [MaxLength(320)]
        public string? Email { get; set; }


        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();


    }
}
