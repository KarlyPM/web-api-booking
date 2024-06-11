using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Booking.Application.Configuration;
using WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using WebApi.Booking.Application.DataBase.Bookings.Queries.GetBookingById;
using WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using WebApi.Booking.Application.DataBase.User.Commands.CreateUser;
using WebApi.Booking.Application.DataBase.User.Commands.DeleteUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using WebApi.Booking.Application.DataBase.User.Queries.GetAllUser;
using WebApi.Booking.Application.DataBase.User.Queries.GetUserBy;

namespace WebApi.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            #region User
            services.AddSingleton(mapper.CreateMapper()); // para mapear los objetos
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();

            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerComand>();
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();

            #endregion

            #region Booking
            services.AddTransient<IGetAllBookingQuery, GetAllBookingQuery>();
            services.AddTransient<IGetBookingByIdQuery, GetBookingByIdQuery>();

            #endregion
            return services;

        }

    }
}
