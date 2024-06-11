using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IGetAllUserQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetAllUserQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<List<GetAllUserModel>> Execute()
        {
            var entity = await _dataBaseServices.User.ToListAsync();

            return _mapper.Map<List<GetAllUserModel>>(entity);
        }
    }
}
