using AdministracionHotelesLocales.Domain.Entities.Base;
using AdministracionHotelesLocales.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class Viajero : EntityBase<Guid>
    {
        [Required(ErrorMessage = "Los nombres del viajero son obligatorios.")]
        public string Nombres { get; set; } = null!;

        [Required(ErrorMessage = "Los apellidos del viajero son obligatorios.")]
        public string Apellidos { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de nacimiento del viajero es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El género del viajero es obligatorio.")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "El tipo de documento del viajero es obligatorio.")]
        public TipoDocumento TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento del viajero es obligatorio.")]
        public string NumeroDocumento { get; set; } = null!;

        [Required(ErrorMessage = "El correo electrónico del viajero es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El teléfono de contacto del viajero es obligatorio.")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        public string TelefonoContacto { get; set; } = null!;

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
