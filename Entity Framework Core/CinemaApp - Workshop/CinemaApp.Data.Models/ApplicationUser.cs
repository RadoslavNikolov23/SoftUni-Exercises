namespace CinemaApp.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser:IdentityUser<Guid>
    {
        public ApplicationUser() 
        {
            this.Id = Guid.NewGuid();
        }

        public ICollection<ApplicationUserMovie> Watchlist { get; set; } = new HashSet<ApplicationUserMovie>();

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
