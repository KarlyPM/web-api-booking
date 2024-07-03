using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Booking.Api;

namespace BG.WorkFlow.APITests.Controllers
{
    public class TestBase
    {
        protected TestServer Server;
        protected IServiceProvider ServiceProvider;

        public TestBase()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.Development.json")
                    .Build()
                )
                .UseStartup<Startup>(); //.UseSerilog();

            Server = new TestServer(builder);
            ServiceProvider = Server.Host.Services;
        }

        protected T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}


