using AdministracionHotelesLocales.Domain.Enums;
using AdministracionHotelesLocales.Domain.Services.HabitacionServices;
using MediatR;

namespace AdministracionHotelesLocales.App.Commands.Habitacion
{
    public class ModificarHabitacionCommandHandler : IRequestHandler<ModificarHabitacionCommand>
    {
        private readonly HabitacionServices _habitacionServices;
        public ModificarHabitacionCommandHandler(HabitacionServices habitacionServices)
        {
            _habitacionServices = habitacionServices;
        }
        public async Task<Unit> Handle(ModificarHabitacionCommand request, CancellationToken cancellationToken)
        {
            await _habitacionServices.ModificarUnaHabitacion(new()
            {
                Id = request.Id,
                Capacidad = request.Capacidad,
                CostoBase = request.CostoBase,
                Impuestos = request.Impuestos,
                Tipo = (TipoHabitacion)Enum.Parse(typeof(TipoHabitacion), request.Tipo, true),
                Ubicacion = request.Ubicacion
            }, cancellationToken);


            return Unit.Value;

        }
    }
}
