using Microsoft.EntityFrameworkCore;
using WebApi.Booking.Domain.Models.Booking;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.DataBase
{
    public interface IDataBaseServices
    {
        DbSet<UserEntity> User { get; set; }

        DbSet<CustomerEntity> Customer { get; set; }

        DbSet<BookingEntity> Booking { get; set; }

        Task<bool> SaveAsync();
    }
}
