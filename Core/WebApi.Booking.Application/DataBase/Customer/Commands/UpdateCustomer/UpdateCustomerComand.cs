using AutoMapper;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerComand : IUpdateCustomerComand
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public UpdateCustomerComand(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            _dataBaseServices.User.Update(entity);
            await _dataBaseServices.SaveAsync();

            return model;
        }
    }
}
