using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Filters;
using AdministracionHotelesLocales.Domain.Services.ReservaServices;
using AutoMapper;
using MediatR;

namespace AdministracionHotelesLocales.App.Queries.Reservas
{
    public class FiltrarReservasQueryHandler : IRequestHandler<FiltrarReservasQuery, IEnumerable<HabitacionDto>>
    {
        private readonly ReservaServices _reservaServices;
        private readonly IMapper _mapper;
        public FiltrarReservasQueryHandler(ReservaServices reservaServices, IMapper mapper)
        {
            _reservaServices = reservaServices;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HabitacionDto>> Handle(FiltrarReservasQuery request, CancellationToken cancellationToken)
        {
            var reservas = await _reservaServices.FiltrarReservasPorDisponibilidadFecha(new FiltroConsultaHabitaciones(
                request.FechaEntrada, 
                request.FechaSalida, 
                request.Ciudad, 
                request.NumeroPersonas));
            List<Habitacion> habitaciones = reservas.Select(reservas => reservas.Habitacion).ToList();

            var reservasDto = _mapper.Map<List<HabitacionDto>>(habitaciones);
            return reservasDto;


        }
    }
}
