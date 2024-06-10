namespace WebApi.Booking.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserModel
    {
        //UserId lo genera la BD
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
