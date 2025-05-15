namespace CinemaApp.Data.Configuration
{
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;

    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(this.GenerateCinemas());
        }

        private IEnumerable<Cinema> GenerateCinemas()
        {
            IEnumerable<Cinema> cinemas = new List<Cinema>()
            {
                new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema city",
                    Location = "Sofia"
                },
                new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema city",
                    Location = "Plovdiv"
                },
                new Cinema()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinemax",
                    Location = "Varna"
                }
            };

            return cinemas;
        }
    }

}
