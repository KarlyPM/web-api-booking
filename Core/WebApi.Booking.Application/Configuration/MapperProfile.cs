using AutoMapper;
using WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using WebApi.Booking.Application.DataBase.User.Commands.CreateUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUser;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap(); //type
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            //CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();

        }
    }
}
