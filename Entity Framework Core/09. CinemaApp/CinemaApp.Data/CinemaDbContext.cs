namespace CinemaApp.Data
{
    using CinemaApp.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class CinemaDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<CinemaMovie> CinemaMovies { get; set; } = null!;
        public virtual DbSet<ApplicationUserMovie> ApplicationUserMovies { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    
}
