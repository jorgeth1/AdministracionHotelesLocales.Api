using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Habitacion
{
    public record ModificarHabitacionCommand(
        [Required] Guid Id,
        [Required] int Capacidad,
        [Required] decimal CostoBase,
        [Required] decimal Impuestos,
        [Required] string Tipo,
        [Required] string Ubicacion) : IRequest;
}
