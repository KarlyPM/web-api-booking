using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IDeleteBookingCommand
    {
        private readonly IDataBaseServices _dataBaseServices;

        public DeleteBookingCommand(IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;

        }

        public async Task<bool> Execute(int bookingId)
        {
            var entity = await _dataBaseServices.Booking.FirstOrDefaultAsync(x => x.BookingId == bookingId);

            if (entity == null) return false;

            _dataBaseServices.Booking.Remove(entity);

            return await _dataBaseServices.SaveAsync();
        }
    }
}
