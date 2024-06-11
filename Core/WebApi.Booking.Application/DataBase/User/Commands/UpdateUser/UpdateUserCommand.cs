using AutoMapper;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            _dataBaseServices.User.Update(entity);
            await _dataBaseServices.SaveAsync();

            return model;
        }
    }
}
