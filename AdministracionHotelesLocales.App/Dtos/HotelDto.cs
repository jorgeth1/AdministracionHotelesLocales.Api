namespace AdministracionHotelesLocales.App.Dtos
{
    public class HotelDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Estrellas { get; set; }
    }
}
