using AdministracionHotelesLocales.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class Reserva : EntityBase<Guid>
    {
        [Required(ErrorMessage = "La fecha de reserva es obligatoria.")]
        public DateTime FechaReserva { get; set; }

        [Required(ErrorMessage = "El ID de la habitación es obligatorio.")]
        public Guid HabitacionId { get; set; }

        public Habitacion Habitacion { get; set; } = null!;

        [Required(ErrorMessage = "El ID del viajero es obligatorio.")]
        public Guid ViajeroId { get; set; }
        public Viajero Viajero { get; set; } = null!;

        [Required(ErrorMessage = "El ID del contacto de emergencia es obligatorio.")]
        public Guid ContactoEmergenciaId { get; set; }
        public ContactoEmergencia ContactoEmergencia { get; set; } = null!;
        public ICollection<Huesped> Huespedes { get; set; } = null!;

    }
}
