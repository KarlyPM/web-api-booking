using WebApi.Booking.Api;
using WebApi.Booking.Application;
using WebApi.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using WebApi.Booking.Application.DataBase.User.Commands.UpdateUser;
using WebApi.Booking.Application.DataBase.User.Queries.GetAllUser;
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

app.MapGet("/api/users", async (IGetAllUserQuery services) =>
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

