﻿using WebApi.Booking.Domain.Models.Booking;

namespace WebApi.Booking.Domain.Models.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }

    }
}
