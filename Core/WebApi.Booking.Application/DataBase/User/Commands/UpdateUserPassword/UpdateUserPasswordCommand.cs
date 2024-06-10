using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseServices _dataBaseServices;

        public UpdateUserPasswordCommand(IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;
        }

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var entity = await _dataBaseServices.User
                .FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (entity == null)
                return false;

            entity.Password = model.Password;

            return await _dataBaseServices.SaveAsync(); //true


        }

    }
}
