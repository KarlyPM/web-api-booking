using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Booking.Domain.Models.Booking;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Persistence.Database
{
    internal class DataBaseServices : DbContext
    {
        public DataBaseServices(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }

        public DbSet<BookingEntity> Booking { get; set; }


    }
}
