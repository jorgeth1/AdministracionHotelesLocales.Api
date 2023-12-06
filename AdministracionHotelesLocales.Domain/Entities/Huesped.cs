using AdministracionHotelesLocales.Domain.Entities.Base;
using AdministracionHotelesLocales.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class Huesped : EntityBase<Guid>
    {
        [Required(ErrorMessage = "Los nombres del huésped son obligatorios.")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "Los apellidos del huésped son obligatorios.")]
        public string Apellidos { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de nacimiento del huésped es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El género del huésped es obligatorio.")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "El tipo de documento del huésped es obligatorio.")]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento del huésped es obligatorio.")]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = "El ID de la reserva es obligatorio.")]
        public Guid ReservaId { get; set; }

        public Reserva Reserva { get; set; } = null!;
    }
}
