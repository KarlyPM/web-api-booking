namespace WebApi.Booking.Application.DataBase.Customer.Queries.GeyCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberModel
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
    }
}
