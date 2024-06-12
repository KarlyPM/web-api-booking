using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Booking.Domain.Models.Booking;

namespace WebApi.Booking.Persistence.Configuration
{
    public class BookingConfiguration
    {
        public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.BookingId);
            entityTypeBuilder.Property(e => e.RegisterDate).IsRequired();
            entityTypeBuilder.Property(e => e.Code).IsRequired();
            entityTypeBuilder.Property(e => e.Type).IsRequired();
            entityTypeBuilder.Property(e => e.UserId).IsRequired();
            entityTypeBuilder.Property(e => e.CustomerId).IsRequired();

            //una entidad user tiene muchas reservas
            entityTypeBuilder.HasOne(e => e.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.UserId);

            entityTypeBuilder.HasOne(e => e.Customer)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.CustomerId);

        }
    }
}
