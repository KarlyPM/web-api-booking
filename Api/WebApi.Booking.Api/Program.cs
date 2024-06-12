using WebApi.Booking.Api;
using WebApi.Booking.Application;
using WebApi.Booking.Application.DataBase.Bookings.Queries.GetAllBooking;
using WebApi.Booking.Common;
using WebApi.Booking.External;
using WebApi.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddAplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);
var app = builder.Build();

app.MapGet("/api/users", async (IGetAllBookingQuery services) =>
{
    //var user = new UpdateUserModel
    //{
    //    UserId = 4,
    //    FirstName = "Karla",
    //    LastName = "P",
    //    UserName = "Nuevo",
    //    Password = "Nuevo"
    //};

    return await services.Execute();
});

app.Run();

