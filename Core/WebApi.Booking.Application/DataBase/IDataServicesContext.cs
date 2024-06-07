using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Booking.Domain.Models.Booking;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.DataBase
{
    public interface IDataServicesContext
    {
        DbSet<UserEntity> User { get; set; }

        DbSet<CustomerEntity> Customer { get; set; }

        DbSet<BookingEntity> Booking { get; set; }

        Task<bool> SaveAsync();
    }
}
