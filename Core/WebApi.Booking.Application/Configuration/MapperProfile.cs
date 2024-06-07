using AutoMapper;
using WebApi.Booking.Application.DataBase.User.Commands.CreateUser;
using WebApi.Booking.Domain.Models.User;

namespace WebApi.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();

        }
    }
}
