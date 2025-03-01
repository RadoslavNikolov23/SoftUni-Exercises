using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }
        
        [Required]
        public int AwayTeamGoals { get; set; }

        public decimal HomeTeamBetRate { get; set; }  
        
        public decimal AwayTeamBetRate { get; set; }   
        
        public decimal DrawBetRate { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(10)]
        public string Result { get; set; } = null!;

        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; } = null!;

        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; } = null!;

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new HashSet<PlayerStatistic>();

        public virtual ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();

    }
}
