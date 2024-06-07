using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Booking.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<IDataServicesContext>(options => options.UseSqlServer());

var app = builder.Build();

app.Run();

