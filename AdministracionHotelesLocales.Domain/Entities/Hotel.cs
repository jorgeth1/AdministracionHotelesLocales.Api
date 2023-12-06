using AdministracionHotelesLocales.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class Hotel : EntityBase<Guid>
    {
        [Required(ErrorMessage = "El nombre del hotel es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Range(1, 5, ErrorMessage = "El número de estrellas debe estar entre 1 y 5.")]
        public int Estrellas { get; set; }

        public bool Disponible { get; set; }

        public ICollection<Habitacion> Habitaciones { get; set; } = new HashSet<Habitacion>();

        public ICollection<AgenciaHotel> AgenciasHoteles { get; set; } = new HashSet<AgenciaHotel>();
    }
}
