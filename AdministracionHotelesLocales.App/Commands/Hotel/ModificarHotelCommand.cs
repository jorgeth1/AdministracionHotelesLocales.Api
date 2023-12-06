using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Hotel
{
    public record ModificarHotelCommand(
          [Required] Guid Id,
          [Required] string Nombre,
          [Required] int Estrellas) : IRequest;
}
