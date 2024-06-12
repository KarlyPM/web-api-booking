namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingByCode
{
    public interface IGetBookingByCodeQuery
    {
        Task<List<GetBookingByCodeModel>> Execute(string type);
    }
}
