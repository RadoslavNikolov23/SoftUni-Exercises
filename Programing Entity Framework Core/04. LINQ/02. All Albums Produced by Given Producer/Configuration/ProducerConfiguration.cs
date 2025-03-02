using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using static MusicHub.Validators.ModelValidators;


namespace MusicHub.Configuration
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(ProducerValidator.producerNameLength);

            entity
                .Property(e => e.Pseudonym)
                .IsRequired(false)
                .HasMaxLength(ProducerValidator.producerPseudonymLength);
           
            entity
                .Property(e => e.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(ProducerValidator.producerPhoneNumberLength);
        }
    }
}
