namespace AdministracionHotelesLocales.Domain.Filters
{
    public record FiltroConsultaHabitaciones(
         DateTime FechaEntrada,
         DateTime FechaSalida,
         string Ciudad,
         int NumeroPersonas);
}
