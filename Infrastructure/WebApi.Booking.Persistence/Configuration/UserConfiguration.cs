using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.UserId );
            entityTypeBuilder.Property(e => e.FirstName).IsRequired();
            entityTypeBuilder.Property(e => e.LastName).IsRequired();
            entityTypeBuilder.Property(e => e.UserName).IsRequired();
            entityTypeBuilder.Property(e => e.Password).IsRequired();

            entityTypeBuilder.HasMany(x => x.Bookings) // viene de la clase booking
                .WithOne(x=> x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
