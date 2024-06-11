namespace WebApi.Booking.Application.DataBase.Bookings.Commands.DeleteBooking
{
    public interface IDeleteBookingCommand
    {
        Task<bool> Execute(int bookingId);
    }
}
