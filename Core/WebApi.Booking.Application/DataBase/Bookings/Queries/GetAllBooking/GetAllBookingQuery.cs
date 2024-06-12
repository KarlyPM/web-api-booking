using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking
{
    public class GetAllBookingQuery : IGetAllBookingQuery
    {
        private readonly IDataBaseServices _dataBaseServices;

        public GetAllBookingQuery(IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;

        }

        public async Task<List<GetAllBookingModel>> Execute()
        {
            var result = await (from booking in _dataBaseServices.Booking
                                join customer in _dataBaseServices.Customer
                                on booking.CustomerId equals customer.CustomerId
                                select new GetAllBookingModel
                                {
                                    BookingId = booking.BookingId,
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber,
                                }).ToListAsync();

            return result;
        }
    }
}
