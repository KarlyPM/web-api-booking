using WebApi.Booking.Api;
using WebApi.Booking.Application;
using WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using WebApi.Booking.Application.DataBase.User.Commands.CreateUser;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUser;
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

app.MapPost("/api/users", async (IUpdateUserCommand services) =>
{
    var user = new UpdateUserModel
    {
        UserId= 4,
        FirstName = "Nuevo",
        LastName = "Nuevo",
        UserName = "Nuevo",
        Password = "Nuevo"
    };

    return await services.Execute(user);
});

app.Run();

