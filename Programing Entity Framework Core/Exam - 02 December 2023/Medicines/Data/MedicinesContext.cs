namespace Medicines.Data
{
    using Medicines.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class MedicinesContext : DbContext
    {
        public MedicinesContext()
        {
        }

        public MedicinesContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Pharmacy> Pharmacies { get; set; } = null!;
        public virtual DbSet<PatientMedicine> PatientsMedicines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicine>(entity =>
            {
                entity
                    .HasKey(e => new { e.PatientId, e.MedicineId });

                entity
                    .HasOne(e => e.Patient)
                    .WithMany(e => e.PatientsMedicines)
                    .HasForeignKey(e => e.PatientId);

                entity
                    .HasOne(e => e.Medicine)
                    .WithMany(e => e.PatientsMedicines)
                    .HasForeignKey(e => e.MedicineId);

            });

        }
    }
}
