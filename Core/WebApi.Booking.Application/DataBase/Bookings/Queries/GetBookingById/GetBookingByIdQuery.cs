using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking;

namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IGetBookingByIdQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetBookingByIdQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<List<GetBookingByIdModel>> Execute(int bookingId)
        {
            var list = await _dataBaseServices.Booking.FirstOrDefaultAsync(x => x.BookingId == bookingId);
            return _mapper.Map<List<GetBookingByIdModel>>(list);
        }
    }
}
