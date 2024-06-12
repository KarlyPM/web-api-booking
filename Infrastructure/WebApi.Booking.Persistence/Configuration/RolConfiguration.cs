using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Booking.Domain.Models.Rol;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Persistence.Configuration
{
    public class RolConfiguration
    {
        public RolConfiguration(EntityTypeBuilder<RolEntity> entityTypeBuilder)
        {

        }
    }
}
