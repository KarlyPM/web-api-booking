using AutoMapper;
using WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingById;
using WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using WebApi.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using WebApi.Booking.Application.DataBase.Customer.Queries.GeyCustomerByDocumentNumber;
using WebApi.Booking.Application.DataBase.User.Commands.CreateUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUser;
using WebApi.Booking.Application.DataBase.User.Queries.GetAllUser;
using WebApi.Booking.Application.DataBase.User.Queries.GetUserBy;
using WebApi.Booking.Domain.Models.Booking;
using WebApi.Booking.Domain.Models.Customer;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap(); //type
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();

            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();

            #endregion

            #region Booking
            CreateMap<BookingEntity, GetAllBookingModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingByIdModel>().ReverseMap();

            #endregion
        }
    }
}
