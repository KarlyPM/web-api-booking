using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Booking.Domain.Models.Customer;

namespace WebApi.Booking.Persistence.Configuration
{
    internal class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e. CustomerId);
            entityTypeBuilder.Property(e => e.FullName).IsRequired();
            entityTypeBuilder.Property(e => e.DocumentNumber).IsRequired();

            //Un Customer tiene muchas reservas
            entityTypeBuilder.HasMany(e => e.Bookings)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
