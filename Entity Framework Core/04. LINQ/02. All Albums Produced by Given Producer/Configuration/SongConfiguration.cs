using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Validators.ModelValidators;

namespace MusicHub.Configuration
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(SongValidator.songNameLength);

            entity
                .Property(e => e.Duration)
                .IsRequired();

            entity
                .Property(e => e.CreatedOn)
                .IsRequired();

            entity
                .Property(e => e.Genre)
                .IsRequired();

            entity
                .Property(e => e.Price)
                .IsRequired();

            entity
                .HasOne(e => e.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(e => e.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(e => e.WriterId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
