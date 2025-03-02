using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Validators.ModelValidators;


namespace MusicHub.Configuration
{
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(WriterValidator.writerNameLength);

            entity
                .Property(e => e.Pseudonym)
                .IsRequired(false)
                .HasMaxLength(WriterValidator.writerPseudonymLength);

        }
    }
}
