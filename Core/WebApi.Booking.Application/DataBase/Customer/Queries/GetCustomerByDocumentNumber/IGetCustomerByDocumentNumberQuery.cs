using WebApi.Booking.Application.DataBase.Customer.Queries.GeyCustomerByDocumentNumber;

namespace WebApi.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public interface IGetCustomerByDocumentNumberQuery
    {
        Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber);
    }
}
