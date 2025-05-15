using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Configuration
{
    public class SongPerformerConfiguration : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> entity)
        {
            entity
                .HasKey(e => new { e.SongId, e.PerformerId });

            entity
                .Property(e => e.SongId)
                .IsRequired();

            entity
                .Property(e => e.PerformerId)
                .IsRequired();

            entity
                .HasOne(e => e.Song)
                .WithMany(s => s.SongPerformers)
                .HasForeignKey(e => e.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.Performer)
                .WithMany(p => p.PerformerSongs)
                .HasForeignKey(e => e.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
