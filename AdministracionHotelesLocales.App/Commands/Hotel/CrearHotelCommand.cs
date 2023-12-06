using AdministracionHotelesLocales.App.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Hotel
{
    public record CrearHotelCommand(
        [Required] string Nombre,
        [Required] int Estrellas,
        bool Disponible) : IRequest<HotelDto>;
}
