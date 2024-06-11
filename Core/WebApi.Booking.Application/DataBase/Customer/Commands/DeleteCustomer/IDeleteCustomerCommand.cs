namespace WebApi.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public interface IDeleteCustomerCommand
    {
        Task<bool> Execute(int customerId);
    }
}
