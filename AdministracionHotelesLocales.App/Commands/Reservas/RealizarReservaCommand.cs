using AdministracionHotelesLocales.App.Dtos;
using MediatR;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.App.Commands.Reservas
{
    public record RealizarReservaCommand(
        [Required] Guid ViajeroId,
        [Required] DateTime FechaReserva,
        [Required] Guid HabitacionId,
        [Required] ContactoEmergenciaRegistro ContactoEmergencia,
        List<HuespedRegistro> Huespedes) : IRequest<ReservaDto>;

    public record ContactoEmergenciaRegistro(
       [Required] string NombreCompleto,
       [Required] string TelefonoContacto);

    public record HuespedRegistro(
        [Required] string Nombres,

        [Required] string Apellidos,

        [Required] DateTime FechaNacimiento,

        [Required] string Genero,

        [Required] string TipoDocumento,

        [Required] string NumeroDocumento);
}
