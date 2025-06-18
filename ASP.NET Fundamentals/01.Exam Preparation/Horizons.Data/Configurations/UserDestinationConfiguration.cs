namespace Horizons.Data.Configurations
{
    using Horizons.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserDestinationConfiguration:IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> entity)
        {
            entity
                .HasKey(ud => new { ud.UserId, ud.DestinationId });

            entity
                .HasQueryFilter(ud=>ud.Destination.IsDeleted == false);

            entity
                .HasOne(ud => ud.User)
                .WithMany()
                .HasForeignKey(ud => ud.UserId);

            entity
                .HasOne(ud => ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId);
        }
    }
}
