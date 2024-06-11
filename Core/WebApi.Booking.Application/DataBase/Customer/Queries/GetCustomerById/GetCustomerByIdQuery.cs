using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IGetCustomerByIdQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<GetCustomerByIdModel> Execute(int customerId)
        {                                                                    //customer id de la tb customer sea igual al customerId q se ingresa   
            var entity = await _dataBaseServices.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return _mapper.Map<GetCustomerByIdModel>(entity);
        }
    }
}
