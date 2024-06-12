using AutoMapper;
using WebApi.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using WebApi.Booking.Domain.Models.Booking;
using WebApi.Booking.Domain.Models.Customer;

namespace WebApi.Booking.Application.DataBase.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDataBaseServices _dataBaseServices;
        private readonly IMapper _mapper;

        public CreateBookingCommand(IDataBaseServices dataBaseServices, IMapper mapper)
        {
            _dataBaseServices = dataBaseServices;
            _mapper = mapper;

        }

        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        {
            var entity = _mapper.Map<BookingEntity>(model);

            await _dataBaseServices.Booking.AddAsync(entity);
            await _dataBaseServices.SaveAsync();

            return model;
        }


    }
}
