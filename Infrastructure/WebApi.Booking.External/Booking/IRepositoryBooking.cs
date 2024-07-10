using WebApi.Booking.Domain.Models.Booking;

namespace Bg.Hcm.InfraestructuraExternal.Familiar
{
    public interface IRepositoryBooking
    {
        public Task<List<BookingEntity>> ConsultaBookingAsync(List<string> cedulas);

    }
}
