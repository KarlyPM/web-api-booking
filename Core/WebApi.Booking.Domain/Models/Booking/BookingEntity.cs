using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Domain.Models.Booking
{
    public class BookingEntity
    {
        public int BookingId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public UserEntity User { get; set; }
        public CustomerEntity Customer { get; set; }

    }
}
