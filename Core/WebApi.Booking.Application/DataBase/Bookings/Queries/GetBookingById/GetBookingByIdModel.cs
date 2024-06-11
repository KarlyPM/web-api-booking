namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdModel
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
    }
}
