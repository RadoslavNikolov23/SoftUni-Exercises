namespace CarDealer.Data
{
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<PartCar> PartsCars { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(entity =>
            {
                entity
                    .HasKey(pc => new { pc.CarId, pc.PartId });

                entity
                    .HasOne(pc => pc.Part)
                    .WithMany(p => p.PartsCars)
                    .HasForeignKey(pc => pc.PartId);

                entity
                    .HasOne(pc => pc.Car)
                    .WithMany(c => c.PartsCars)
                    .HasForeignKey(pc => pc.CarId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity
                    .HasOne(s => s.Customer)
                    .WithMany(cu => cu.Sales)
                    .HasForeignKey(s => s.CustomerId);

                entity
                    .HasOne(s => s.Car)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(s => s.CarId);
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity
                    .HasOne(p => p.Supplier)
                    .WithMany(s => s.Parts)
                    .HasForeignKey(p => p.SupplierId);
            });
        }
    }
}
