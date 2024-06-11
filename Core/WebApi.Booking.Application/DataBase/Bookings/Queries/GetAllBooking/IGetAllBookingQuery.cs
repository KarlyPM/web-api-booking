namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking
{
    public interface IGetAllBookingQuery
    {
        Task<List<GetAllBookingQuery>> Execute();
    }
}
