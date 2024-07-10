using AutoMapper;
using Bg.Hcm.InfraestructuraExternal.ReportOracleBI;
using Microsoft.Extensions.Configuration;
using System.Xml.Serialization;
using WebApi.Booking.Domain.Models.Booking;

namespace Bg.Hcm.InfraestructuraExternal.Familiar
{
    public class RepositoryBooking : IRepositoryBooking
    {
        private readonly string spConsulta;
        private readonly IConfiguration _conf;
        private readonly IRepositoryReportOracleBI _reportRequestBI;

        public RepositoryBooking(IConfiguration conf, IMapper map, IRepositoryReportOracleBI reportRequestBI)
        {
            _conf = conf;
            _reportRequestBI = reportRequestBI;
            // spConsulta = _conf.GetSection("StoredProcedure:External:Booking:Consulta").Value;
        }

        public async Task<List<BookingEntity>> ConsultaBookingAsync(List<string> id)
        {
            List<BookingEntity> familiarEmpleadoErpDTOs = new();
            Dictionary<string, List<string>> parametros = new()
            {
                [""] = id
            };

            try
            {
                var result = await _reportRequestBI.ResponseReport(spConsulta, parametros);

                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("nulo");

                }

                familiarEmpleadoErpDTOs = DeserializeReportResult(result!);
            }
            catch (Exception ex)
            {
                throw;
            }
            return familiarEmpleadoErpDTOs;

        }

        public static List<BookingEntity> DeserializeReportResult(string xmlResult)
        {
            List<BookingEntity> bookingDTOs = new();

            XmlSerializer serializer = new(typeof(BookingEntity));

            using (StringReader reader = new(xmlResult))
            {
                var bookings = (BookingEntity)serializer.Deserialize(reader)!;

                //foreach (var booking in bookings)
                //{
                //    bookingDTOs.Add(booking);
                //}
            }

            return bookingDTOs;
        }



    }
}
