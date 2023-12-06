using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.Domain.Enums;
using AdministracionHotelesLocales.Domain.Services.HabitacionServices;
using AutoMapper;
using MediatR;

namespace AdministracionHotelesLocales.App.Commands.Habitacion
{
    public class CrearHabitacionCommandHandler : IRequestHandler<CrearHabitacionCommand, HabitacionDto>
    {
        private readonly IMapper _mapper;
        private readonly HabitacionServices _habitacionServices;
        public CrearHabitacionCommandHandler(HabitacionServices habitacionServices, IMapper mapper)
        {
            _habitacionServices = habitacionServices;
            _mapper = mapper;
        }
        public async Task<HabitacionDto> Handle(CrearHabitacionCommand request, CancellationToken cancellationToken)
        {
            var nuevaHabitacion = await _habitacionServices.CrearUnaHabitacion(new()
            {
                Capacidad = request.Capacidad,
                Disponible = request.Disponible,
                CostoBase = request.CostoBase,
                Impuestos = request.Impuestos,
                Tipo = (TipoHabitacion)Enum.Parse(typeof(TipoHabitacion), request.Tipo, true),
                Ubicacion = request.Ubicacion,
                HotelId = request.HotelId
            }, cancellationToken);

            var nuevaHabitacionDto = _mapper.Map<HabitacionDto>(nuevaHabitacion);
            return nuevaHabitacionDto;
        }
    }
}
