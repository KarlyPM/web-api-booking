using Microsoft.EntityFrameworkCore;
using WebApi.Booking.Application.DataBase;
using WebApi.Booking.Domain.Models.Booking;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;
using WebApi.Booking.Persistence.Configuration;

namespace WebApi.Booking.Persistence.Database
{
    public class DataServicesContext : DbContext, IDataBaseServices
    {
        public DataServicesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }

        public DbSet<BookingEntity> Booking { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //add configuration
            EntityConfigurationChanged(modelBuilder);
        }

        private void EntityConfigurationChanged(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }

    }
}
