using AdministracionHotelesLocales.Domain.Services.HabitacionServices;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Habitacion
{
    public record CambiarEstadoHabilitadoHabitacionCommand(
        [Required] Guid Id,
        [Required] bool Disponible) : IRequest;

    public class CambiarEstadoHabilitadoHabitacionCommandHandler : IRequestHandler<CambiarEstadoHabilitadoHabitacionCommand>
    {
        private readonly HabitacionServices _habitacionServices;
        public CambiarEstadoHabilitadoHabitacionCommandHandler(HabitacionServices habitacionServices)
        {
            _habitacionServices = habitacionServices;
        }
        public async Task<Unit> Handle(CambiarEstadoHabilitadoHabitacionCommand request, CancellationToken cancellationToken)
        {
            await _habitacionServices.ActualizarEstadoPorHabitacion(request.Id, request.Disponible, cancellationToken);
            return Unit.Value;
        }
    }
}
