namespace Cadastre.Data
{
    using Cadastre.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class CadastreContext : DbContext
    {
        public CadastreContext()
        {
            
        }

        public CadastreContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public virtual DbSet<Citizen> Citizens { get; set; } = null!;

        public virtual DbSet<District> Districts { get; set; } = null!;

        public virtual DbSet<Property> Properties { get; set; } = null!;

        public virtual DbSet<PropertyCitizen> PropertiesCitizens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyCitizen>(entity =>
            {
                entity
                    .HasKey(e => new { e.PropertyId, e.CitizenId });

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.PropertiesCitizens)
                    .HasForeignKey(d => d.CitizenId);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p!.PropertiesCitizens)
                    .HasForeignKey(d => d.PropertyId);
            });
        }
    }
}
