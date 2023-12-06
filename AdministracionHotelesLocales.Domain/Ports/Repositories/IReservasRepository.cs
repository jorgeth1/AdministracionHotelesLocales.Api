using AdministracionHotelesLocales.Domain.Entities;

namespace AdministracionHotelesLocales.Domain.Ports.Repositories
{
    public interface IReservasRepository
    {
        Task<Reserva> ReservarHabitacion(Reserva reserva);
        Task<IEnumerable<Reserva>> FiltrarReservas(DateTime fecha);
        Task RegistrarTodosHuespedesReserva(IEnumerable<Huesped> huespedes);
        Task RegistrarContactoEmergenciaReserva(ContactoEmergencia contactoEmergencia);
    }
}
