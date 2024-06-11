using AutoMapper;
using WebApi.Booking.Domain.Models.Customer;

namespace WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer
{
    public class CreateCustomerComand : ICreateCustomerCommand
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public CreateCustomerComand(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);

            await _dataBaseServices.Customer.AddAsync(entity);
            await _dataBaseServices.SaveAsync();

            return model;
        }

    }
}
