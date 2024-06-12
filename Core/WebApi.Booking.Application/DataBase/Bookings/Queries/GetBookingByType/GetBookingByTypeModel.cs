namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingByType
{
    public class GetBookingByTypeModel
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }
}
