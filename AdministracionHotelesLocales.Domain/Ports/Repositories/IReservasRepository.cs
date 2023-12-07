using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Filters;

namespace AdministracionHotelesLocales.Domain.Ports.Repositories
{
    public interface IReservasRepository
    {
        Task<Reserva> ReservarHabitacion(Reserva reserva);
        Task<IEnumerable<Reserva>> FiltrarReservas(FiltroConsultaHabitaciones filtroConsultaHabitaciones);
        Task RegistrarTodosHuespedesReserva(IEnumerable<Huesped> huespedes);
        Task RegistrarContactoEmergenciaReserva(ContactoEmergencia contactoEmergencia);
    }
}
