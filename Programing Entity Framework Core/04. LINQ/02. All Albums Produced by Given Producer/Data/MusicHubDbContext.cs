namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Configuration;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album>? Albums { get; set; }
        public DbSet<Performer>? performers { get; set; }
        public DbSet<Producer>? Producers { get; set; }
        public DbSet<Song>? Songs { get; set; }
        public DbSet<SongPerformer>? SongPerformers { get; set; }
        public DbSet<Writer>? Writers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //This will apply on the other Configuration automaticlly, as long as they are in the same assembly os the SongConfiguration!!!
            builder.ApplyConfigurationsFromAssembly(typeof(SongConfiguration).Assembly);
        }
    }
}
