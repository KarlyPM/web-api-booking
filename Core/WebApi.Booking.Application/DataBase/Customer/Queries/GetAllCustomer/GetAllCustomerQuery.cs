using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery : IGetAllCustomerQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetAllCustomerQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<List<GetAllCustomerModel>> Execute()
        {
            var list = await _dataBaseServices.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomerModel>>(list);
        }
    }
}
