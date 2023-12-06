using AdministracionHotelesLocales.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class ContactoEmergencia : EntityBase<Guid>
    {
        [Required(ErrorMessage = "El nombre completo del contacto de emergencia es obligatorio.")]
        public string NombreCompleto { get; set; } = null!;

        [Required(ErrorMessage = "El número de teléfono de contacto es obligatorio.")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        public string TelefonoContacto { get; set; } = null!;

        [Required(ErrorMessage = "La reserva asociada es obligatoria.")]
        public Guid ReservaId { get; set; }
        public Reserva Reserva { get; set; } = null!;
    }
}
