using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Validators.ModelValidators;

namespace MusicHub.Configuration
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(AlbumValidator.albumNameLength);

            entity
                .Property(e => e.ReleaseDate)
                .IsRequired();

            entity
                .Property(e => e.ProducerId)
                .IsRequired(false);

            entity
                .HasOne(e => e.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(e => e.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
