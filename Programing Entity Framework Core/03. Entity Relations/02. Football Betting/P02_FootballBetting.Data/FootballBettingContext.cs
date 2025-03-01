using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;
using static P02_FootballBetting.Data.StringConfigurations;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        public FootballBettingContext()
        {
        }

        public virtual DbSet<Bet>? Bets { get; set; }
        public virtual DbSet<Color>? Colors { get; set; }
        public virtual DbSet<Country>? Countries { get; set; }
        public virtual DbSet<Game>? Games { get; set; }
        public virtual DbSet<Player>? Players { get; set; }
        public virtual DbSet<PlayerStatistic>? PlayersStatistics { get; set; }
        public virtual DbSet<Position>? Positions { get; set; }
        public virtual DbSet<Team>? Teams { get; set; }
        public virtual DbSet<Town>? Towns { get; set; }
        public virtual DbSet<User>? Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConnectionAddress);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Making of a Composite Key
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.GameId, ps.PlayerId });

            //Making a default value to the property IsInjured of Enity Player
            modelBuilder.Entity<Player>()
                .Property(p => p.IsInjured)
                .HasDefaultValue(false);

            //Connecting the foreign key to the primary key (HomeTeamColordId to ColorId), you have to do this by the Fluent API!
            modelBuilder.Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            //Connecting the foreign key to the primary key (SecondaryTeamColordId to ColorId), you have to do this by the Fluent API!
            modelBuilder.Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            //In the Game entity has the same problem!
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            //Gives me an error of a cascade cycle, so this code is necessary
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Town)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
