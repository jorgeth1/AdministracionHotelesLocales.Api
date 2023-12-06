using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Ports.Repositories;
using AdministracionHotelesLocales.Infra.Ports;

namespace AdministracionHotelesLocales.Infra.Adapters
{
    [Repository]
    public class ReservasRepository : IReservasRepository
    {
        private readonly IGenericRepository<Reserva> _reservaDataSet;
        private readonly IGenericRepository<Huesped> _huespedDataSet;
        private readonly IGenericRepository<ContactoEmergencia> _contactoEmergenciaDataSet;
        public ReservasRepository(IGenericRepository<Reserva> reservaDataSet,
            IGenericRepository<Huesped> huespedDataSet,
             IGenericRepository<ContactoEmergencia> contactoEmergenciaDataSet)
        {
            _reservaDataSet = reservaDataSet;
            _huespedDataSet = huespedDataSet;
            _contactoEmergenciaDataSet = contactoEmergenciaDataSet;

        }
        public async Task<Reserva> ReservarHabitacion(Reserva reserva)
        {
            await _reservaDataSet.AddAsync(reserva);
            return reserva;
        }

        public async Task RegistrarTodosHuespedesReserva(IEnumerable<Huesped> huespedes)
        {
            foreach (var huesped in huespedes)
            {
                await _huespedDataSet.AddAsync(huesped);
            }
        }

        public async Task RegistrarContactoEmergenciaReserva(ContactoEmergencia contactoEmergencia)
        {
            await _contactoEmergenciaDataSet.AddAsync(contactoEmergencia);
        }

        public async Task<IEnumerable<Reserva>> FiltrarReservas(DateTime fecha)
        {
            return await _reservaDataSet.GetAsync(reserva => reserva.FechaReserva != fecha);
        }
    }
}
