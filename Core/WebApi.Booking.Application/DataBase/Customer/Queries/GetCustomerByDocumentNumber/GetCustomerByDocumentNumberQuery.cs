using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Booking.Application.DataBase.Customer.Queries.GeyCustomerByDocumentNumber;

namespace WebApi.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberQuery : IGetCustomerByDocumentNumberQuery
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentNumberQuery(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber)
        {
            var list = await _dataBaseServices.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);
            return _mapper.Map<GetCustomerByDocumentNumberModel>(list);
        }
    }
}
