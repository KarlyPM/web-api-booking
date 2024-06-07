using Microsoft.EntityFrameworkCore;
using WebApi.Booking.Application.Interfaces;
using WebApi.Booking.Domain.Models.User;
using WebApi.Booking.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataServicesContext>(options => 
options.UseSqlServer(builder.Configuration["SQLConnectionStrings"]));

builder.Services.AddScoped<IDataServicesContext, DataServicesContext>();

var app = builder.Build();


app.MapPost("/api/users", async (IDataServicesContext dataServices) =>
{
    var user = new UserEntity
    {
        FirstName = "John",
        LastName = "Doe",
        UserName = "johndoe",
        Password = "password12"
    };
    Console.WriteLine($"ID de usuario: {user.UserId}");
    Console.WriteLine($"Nombre: {user.FirstName} {user.LastName}");
    Console.WriteLine($"Nombre de usuario: {user.UserName}");
    Console.WriteLine($"Contraseña: {user.Password}");

    try
    {
        await dataServices.User.AddAsync(user);
        await dataServices.SaveAsync();
        return "Create ok";
    }
    catch (DbUpdateException ex)
    {
        // Log the detailed error
        Console.WriteLine($"Error al guardar los cambios: {ex.InnerException?.Message}");
        return "Error al crear el usuario";
    }
});


app.MapGet("/api/users", async (IDataServicesContext dataServices) =>
{
    var result = await dataServices.User.ToListAsync();
    return result;
});
app.Run();

