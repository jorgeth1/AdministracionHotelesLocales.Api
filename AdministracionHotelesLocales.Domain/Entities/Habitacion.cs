using AdministracionHotelesLocales.Domain.Entities.Base;
using AdministracionHotelesLocales.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class Habitacion : EntityBase<Guid>
    {
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad debe ser mayor que cero.")]
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }

        [Required(ErrorMessage = "El costo base es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo base debe ser mayor que cero.")]
        public decimal CostoBase { get; set; }

        [Required(ErrorMessage = "El costo base es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo base debe ser mayor que cero.")]
        public decimal Impuestos { get; set; }

        [Required(ErrorMessage = "El tipo de Habitacion del huésped es obligatorio.")]
        public TipoHabitacion Tipo { get; set; }

        [Required(ErrorMessage = "La ubicación de la habitación es obligatoria.")]
        public string Ubicacion { get; set; } = null!;


        [Required(ErrorMessage = "El ID del hotel es obligatorio.")]
        public Guid HotelId { get; set; }

        public Hotel Hotel { get; set; } = null!;

        public ICollection<Reserva> Reservas { get; set; } = new HashSet<Reserva>();

    }
}
