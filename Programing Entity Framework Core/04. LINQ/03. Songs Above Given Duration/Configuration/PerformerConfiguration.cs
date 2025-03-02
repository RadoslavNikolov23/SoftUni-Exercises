using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Validators.ModelValidators;


namespace MusicHub.Configuration
{
    public class PerformerConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(PerformerValidator.performerFisrtNameLength);

            entity
                .Property(e => e.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(PerformerValidator.performerLastNameLength);

            entity
                .Property(e => e.Age)
                .IsRequired();

            entity
                .Property(e => e.NetWorth)
                .IsRequired();

        }
    }
}
