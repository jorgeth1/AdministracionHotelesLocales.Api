using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Hotel
{
    public record CambiarEstadoHabilitadoCommand(
        [Required] Guid Id,
        [Required] bool Habilitado) : IRequest;
}
