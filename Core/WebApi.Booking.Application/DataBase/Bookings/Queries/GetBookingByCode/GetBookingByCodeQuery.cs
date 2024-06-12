using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingByCode
{
    public class GetBookingByCodeQuery : IGetBookingByCodeQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetBookingByCodeQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<List<GetBookingByCodeModel>> Execute(string type)
        {
            var entity = await _dataBaseServices.Booking.FirstOrDefaultAsync(x => x.Type == type);

            return _mapper.Map<List<GetBookingByCodeModel>>(entity);

        }
    }
}
