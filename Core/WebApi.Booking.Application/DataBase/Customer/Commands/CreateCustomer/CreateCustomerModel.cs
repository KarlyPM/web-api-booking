using WebApi.Booking.Domain.Models.Booking;

namespace WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer
{
    public class CreateCustomerModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }

    }
}
