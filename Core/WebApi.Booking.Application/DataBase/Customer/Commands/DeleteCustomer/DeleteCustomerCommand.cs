using Microsoft.EntityFrameworkCore;

namespace WebApi.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDataBaseServices _dataBaseServices;

        public DeleteCustomerCommand(IDataBaseServices dataBaseServices)
        {
            _dataBaseServices = dataBaseServices;

        }

        public async Task<bool> Execute(int customerId)
        {
            var entity = await _dataBaseServices.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (entity == null)
                return false;

            _dataBaseServices.Customer.Remove(entity);

            return await _dataBaseServices.SaveAsync();
        }
    }
}
