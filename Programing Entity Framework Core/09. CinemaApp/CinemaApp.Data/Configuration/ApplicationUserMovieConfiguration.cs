namespace CinemaApp.Data.Configuration
{
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder
                .HasKey(um => new { um.ApplicationUserId, um.MovieId });

            builder
                .HasOne(um => um.Movie)
                .WithMany(m => m.MovieApplicationUsers)
                .HasForeignKey(um => um.MovieId);

            builder
                .HasOne(um => um.ApplicationUser)
                .WithMany(u => u.Watchlist)
                .HasForeignKey(um => um.ApplicationUserId);
        }
    }

}
