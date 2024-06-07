using WebApi.Booking.Api;
using WebApi.Booking.Application;
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


app.Run();

