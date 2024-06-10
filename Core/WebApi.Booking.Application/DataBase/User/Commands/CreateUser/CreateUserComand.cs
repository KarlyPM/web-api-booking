using AutoMapper;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            await _dataBaseServices.User.AddAsync(entity);
            await _dataBaseServices.SaveAsync();

            return model;
        }
    }
}
