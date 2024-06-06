using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Booking.Domain.Models.Customer
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }

    }
}
