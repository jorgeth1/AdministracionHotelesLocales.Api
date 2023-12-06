using AdministracionHotelesLocales.App.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Habitacion
{
    public record CrearHabitacionCommand(
        [Required] int Capacidad,
        bool Disponible,
        [Required] decimal CostoBase,
        [Required] decimal Impuestos,
        [Required] string Tipo,
        [Required] string Ubicacion,
        [Required] Guid HotelId) : IRequest<HabitacionDto>;
}
