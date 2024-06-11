using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public interface IUpdateCustomerComand
    {
        Task<UpdateCustomerModel> Execute(UpdateCustomerModel model);
    }
}
