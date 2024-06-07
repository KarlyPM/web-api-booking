using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Booking.Application.Configuration;

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

            return services;

        }

    }
}
