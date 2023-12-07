using AdministracionHotelesLocales.App.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Queries.Reservas
{
    public record FiltrarReservasQuery(
        [Required] DateTime FechaEntrada,
        [Required] DateTime FechaSalida,
        int NumeroPersonas,
        string Ciudad) : IRequest<IEnumerable<HabitacionDto>>;
}
