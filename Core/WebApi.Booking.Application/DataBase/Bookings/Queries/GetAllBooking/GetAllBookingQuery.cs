using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;

namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking
{
    public class GetAllBookingQuery : IGetAllBookingQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetAllBookingQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<List<GetAllBookingQuery>> Execute()
        {
            var list = await _dataBaseServices.Booking.ToListAsync();
            return _mapper.Map<List<GetAllBookingQuery>>(list);
        }
    }
}
