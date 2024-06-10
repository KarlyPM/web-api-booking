using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public DeleteUserCommand(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<bool> Execute(int userId)
        {
            var entity = await _dataBaseServices.User.FirstOrDefaultAsync(x => x.UserId == userId);

            if (entity == null)
                return false;


            _dataBaseServices.User.Remove(entity);

            return await _dataBaseServices.SaveAsync();
            
        }
    }
}
