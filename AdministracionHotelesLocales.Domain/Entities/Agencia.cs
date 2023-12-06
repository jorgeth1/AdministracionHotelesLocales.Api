using AdministracionHotelesLocales.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class Agencia : EntityBase<Guid>
    {
        [Required(ErrorMessage = "El nombre de la agencia es obligatorio.")]
        public string Nombre { get; set; } = null!;

        public ICollection<AgenciaHotel> HotelesPreferidos { get; set; } = new HashSet<AgenciaHotel>();

    }
}
