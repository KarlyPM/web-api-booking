using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.User.Queries.GetUserBy
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<GetUserByIdModel> Execute(int userId)
        {
            var entity = await _dataBaseServices.User.FirstOrDefaultAsync(x => x.UserId == userId);

            return _mapper.Map<GetUserByIdModel>(entity);
        }
    }
}
