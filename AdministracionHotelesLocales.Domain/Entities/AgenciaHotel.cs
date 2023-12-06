using AdministracionHotelesLocales.Domain.Entities.Base;

namespace AdministracionHotelesLocales.Domain.Entities
{
    public class AgenciaHotel : EntityBase<Guid>
    {
        public Hotel Hotel { get; set; } = null!;
        public Guid HotelId { get; set; }
        public Agencia Agencia { get; set; } = null!;
        public Guid AgenciaId { get; set; }

    }
}
