using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Services.ReservaServices;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Queries.Reservas
{
    public record FiltrarReservasQuery(
        [Required] DateTime Fecha) : IRequest<IEnumerable<HabitacionDto>>;

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
            var reservas = await _reservaServices.FiltrarReservasHabitacion(request.Fecha);
            List<Habitacion> habitaciones = reservas.Select(reservas => reservas.Habitacion).ToList();

            var reservasDto = _mapper.Map<List<HabitacionDto>>(habitaciones);
            return reservasDto;


        }
    }
}
