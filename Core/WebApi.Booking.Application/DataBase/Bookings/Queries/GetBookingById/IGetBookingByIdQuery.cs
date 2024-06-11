namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingById
{
    public interface IGetBookingByIdQuery
    {
        Task<List<GetBookingByIdModel>> Execute();
    }
}
