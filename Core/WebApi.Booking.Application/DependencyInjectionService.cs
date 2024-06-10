using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Booking.Application.Configuration;
using WebApi.Booking.Application.DataBase.User.Commands.CreateUser;
using WebApi.Booking.Application.DataBase.User.Commands.DeleteUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

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

            services.AddSingleton(mapper.CreateMapper()); //para mapear los objetos
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();

            return services;

        }

    }
}
