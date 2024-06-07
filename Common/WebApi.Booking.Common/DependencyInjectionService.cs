using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Booking.Common
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;

        }

    }
}
