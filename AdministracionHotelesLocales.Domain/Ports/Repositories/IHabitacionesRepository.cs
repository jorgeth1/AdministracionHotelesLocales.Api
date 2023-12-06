using AdministracionHotelesLocales.Domain.Entities;

namespace AdministracionHotelesLocales.Domain.Ports.Repositories
{
    public interface IHabitacionesRepository
    {
        Task<Habitacion> CrearNuevaHabitacion(Habitacion habitacion);
        Task<Habitacion> ObtenerHabitacionPorId(Guid id);
        Task ModificarValoresHabitacion(Habitacion habitacion);
    }

}
