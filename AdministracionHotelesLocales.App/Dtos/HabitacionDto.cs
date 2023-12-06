using AdministracionHotelesLocales.Domain.Enums;

namespace AdministracionHotelesLocales.App.Dtos
{
    public class HabitacionDto
    {
        public Guid Id { get; set; }
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }
        public decimal CostoBase { get; set; }
        public decimal Impuestos { get; set; }
        public string Tipo { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;

        public Guid HotelId { get; set; }

    }
}
