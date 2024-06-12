using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Booking.Application.DataBase;
using WebApi.Booking.Persistence.Database;

namespace WebApi.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataServicesContext>(options =>
                        options.UseSqlServer(configuration["SQLConnectionStrings"]));

            services.AddScoped<IDataBaseServices, DataServicesContext>();


            //System.Reflection.Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(a => a.Name.StartsWith("Repository") && !a.IsAbstract && !a.IsInterface)
            //    .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
            //    .ToList()
            //    .ForEach(typesToRegister =>
            //    {
            //        typesToRegister.serviceTypes.ForEach(
            //            typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
            //    });

            return services;

        }

    }
}
