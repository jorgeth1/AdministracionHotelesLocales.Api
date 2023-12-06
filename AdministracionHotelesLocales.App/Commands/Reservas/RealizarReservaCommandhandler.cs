using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Enums;
using AdministracionHotelesLocales.Domain.Services.ReservaServices;
using AutoMapper;
using MediatR;

namespace AdministracionHotelesLocales.App.Commands.Reservas
{
    public class RealizarReservaCommandhandler : IRequestHandler<RealizarReservaCommand, ReservaDto>
    {
        private readonly ReservaServices _reservaServices;
        private readonly IMapper _mapper;
        public RealizarReservaCommandhandler(ReservaServices reservaServices, IMapper mapper)
        {
            _reservaServices = reservaServices;
            _mapper = mapper;
        }
        public async Task<ReservaDto> Handle(RealizarReservaCommand request, CancellationToken cancellationToken)
        {
            List<Huesped> huespedes = request.Huespedes is null ? new List<Huesped>()
                : request.Huespedes.Select(huesped => new Huesped
                {
                    Nombres = huesped.Nombres,
                    Apellidos = huesped.Apellidos,
                    FechaNacimiento = huesped.FechaNacimiento,
                    Genero = (Genero)Enum.Parse(typeof(Genero), huesped.Genero, true),
                    TipoDocumento = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), huesped.TipoDocumento, true),
                    NumeroDocumento = huesped.NumeroDocumento
                }).ToList();

            var reservaRealizada = await _reservaServices.ReservarHabitacion(new()
            {
                FechaReserva = request.FechaReserva,
                ViajeroId = request.ViajeroId,
                HabitacionId = request.HabitacionId,
                Huespedes = huespedes,
                ContactoEmergencia = new()
                {
                    NombreCompleto = request.ContactoEmergencia.NombreCompleto,
                    TelefonoContacto = request.ContactoEmergencia.TelefonoContacto
                }
            }, cancellationToken);

            var reservaRealizadaDto = _mapper.Map<ReservaDto>(reservaRealizada);


            return reservaRealizadaDto;
        }
    }
}
