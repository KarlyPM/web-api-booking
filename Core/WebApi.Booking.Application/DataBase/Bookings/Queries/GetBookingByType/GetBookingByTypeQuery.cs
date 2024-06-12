using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingByType
{
    public class GetBookingByTypeQuery : IGetBookingByTypeQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetBookingByTypeQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<List<GetBookingByTypeModel>> Execute(string type)
        {
            var entity = await _dataBaseServices.Booking.FirstOrDefaultAsync(x => x.Type == type);

            return _mapper.Map<List<GetBookingByTypeModel>>(entity);

        }
    }
}
